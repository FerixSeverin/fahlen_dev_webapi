using System;
using System.Threading.Tasks;
using fahlen_dev_webapi.Domain;

namespace fahlen_dev_webapi.Services
{
  public interface IIdentityService
  {
    Task<AuthenticationResult> RegisterAsync(string email, string password);
    Task<AuthenticationResult> LoginAsync(string email, string password);
    Task<AuthenticationResult> RefreshTokenAsync(string refreshToken);

    Task<AuthenticationResult> LogoutAsync(string refreshToken);
  }
}