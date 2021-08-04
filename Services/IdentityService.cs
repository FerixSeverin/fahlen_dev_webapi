using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using fahlen_dev_webapi.Data;
using fahlen_dev_webapi.Domain;
using fahlen_dev_webapi.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace fahlen_dev_webapi.Services
{
  public class IdentityService : IIdentityService
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtSettings _jwtSettings;
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly FoodContext _context;
    public IdentityService(UserManager<IdentityUser> userManager, JwtSettings jwtSettings, TokenValidationParameters tokenValidationParameters, FoodContext context)
    {
      _userManager = userManager;
      _jwtSettings = jwtSettings;
      _tokenValidationParameters = tokenValidationParameters;
      _context = context;
    }

    public async Task<AuthenticationResult> LoginAsync(string email, string password)
    {
      var user = await _userManager.FindByEmailAsync(email);
      if (user is null)
      {
        return new AuthenticationResult
        {
          Errors = new[] { "User does not exist" }
        };
      }

      var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);

      if (!userHasValidPassword) {
        return new AuthenticationResult
        {
          Errors = new[] { "User/password combination is wrong" }
        };
      }

      return await GenerateAuthenticationResultForUserAsync(user);
    }

    public async Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken)
    {
        var validatedToken = GetPrincipalFromToken(token);

        if(validatedToken is not null) {
            return new AuthenticationResult{
                Errors = new[] {"Invalid Token"}
            };
        }

        var expiryDateUnix = long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

        var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(expiryDateUnix).Subtract(_jwtSettings.TokenLifeTime);

        if(expiryDateTimeUtc > DateTime.UtcNow) {
            return new AuthenticationResult {Errors = new[] {"This token hasn't expired yet"}};
        }

        var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

        var storedRefreshToken = await _context.RefreshTokens.SingleOrDefaultAsync(x => x.Token == refreshToken);

        if (storedRefreshToken is null) {
            return new AuthenticationResult {Errors = new[] {"This refresh token does not exist"}};
        }

        if(DateTime.UtcNow > storedRefreshToken.ExpiryDate) {
            return new AuthenticationResult {Errors = new[] {"This refresh token has expired"}};
        }

        if(storedRefreshToken.Invalidated) {
            return new AuthenticationResult {Errors = new[] {"This refresh has been invalidated"}};
        }

        if(storedRefreshToken.Used) {
            return new AuthenticationResult {Errors = new[] {"This refresh token has been used"}};
        }

        if(storedRefreshToken.JwtId != jti) {
            return new AuthenticationResult {Errors = new[] {"This refresh token does not match this JWT"}};
        }

        storedRefreshToken.Used = true;

        _context.RefreshTokens.Update(storedRefreshToken);
        await _context.SaveChangesAsync();

        var user = await _userManager.FindByIdAsync(validatedToken.Claims.Single(x => x.Type == "id").Value);

        return await GenerateAuthenticationResultForUserAsync(user);
    }

    private ClaimsPrincipal GetPrincipalFromToken(string token) {
        var tokenHandler = new JwtSecurityTokenHandler();

        try {
            var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
            if(!IsJwtWithValidSecurityAlgorithm(validatedToken)){
                return null;
            }

            return principal;
        }
        catch
        {
            return null;
        }
    }

    private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken) {
        return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase);
    }

    public async Task<AuthenticationResult> RegisterAsync(string email, string password)
    {
      var existingUser = await _userManager.FindByEmailAsync(email);
      if (existingUser is not null)
      {
        return new AuthenticationResult
        {
          Errors = new[] { "User with this email adress already exists" }
        };
      }

      var newUser = new IdentityUser
      {
        Email = email,
        UserName = email
      };

      var createUser = await _userManager.CreateAsync(newUser, password);

      if (!createUser.Succeeded)
      {
        return new AuthenticationResult
        {
          Errors = createUser.Errors.Select(x => x.Description)
        };
      }

      return await GenerateAuthenticationResultForUserAsync(newUser);
    }



    private async Task<AuthenticationResult> GenerateAuthenticationResultForUserAsync(IdentityUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]{
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("id", user.Id),
            }),
            Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifeTime),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        var refreshToken = new RefreshToken {
            JwtId = token.Id,
            UserId = user.Id,
            CreationDate = DateTime.UtcNow,
            ExpiryDate = DateTime.UtcNow.AddMonths(6)
        };

        await _context.RefreshTokens.AddAsync(refreshToken);
        await _context.SaveChangesAsync();

        return new AuthenticationResult
        {
            Success = true,
            Token = tokenHandler.WriteToken(token),
            RefreshToken = refreshToken.Token
        };
    }
  }
}