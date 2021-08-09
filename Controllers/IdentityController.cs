using System;
using System.Linq;
using System.Threading.Tasks;
using fahlen_dev_webapi.Contracts;
using fahlen_dev_webapi.Contracts.Requests;
using fahlen_dev_webapi.Contracts.Response;
using fahlen_dev_webapi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fahlen_dev_webapi.Controllers
{
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IdentityController(IIdentityService identityService, IHttpContextAccessor httpContextAccessor)
        {
            _identityService = identityService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthSuccessResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AuthFailResponse))]
        public async Task<IActionResult> Register([FromBody]UserRegistrationRequest request) {
            if(!ModelState.IsValid) {
                return BadRequest(new AuthFailResponse {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

            if (!authResponse.Success) {
                return BadRequest(new AuthFailResponse {
                    Errors = authResponse.Errors
                });
            }

            CookieOptions option = CookieProvider();
            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", authResponse.RefreshToken, option);

            return Ok(new AuthSuccessResponse {
                Token = authResponse.Token,
            });
        }

        [HttpPost(ApiRoutes.Identity.Login)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthSuccessResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AuthFailResponse))]
        public async Task<IActionResult> Login([FromBody]UserLoginRequest request) {
            var authResponse = await _identityService.LoginAsync(request.Email, request.Password);

            if (!authResponse.Success) {
                return BadRequest(new AuthFailResponse {
                    Errors = authResponse.Errors
                });
            }

            CookieOptions option = CookieProvider();
            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", authResponse.RefreshToken, option);

            return Ok(new AuthSuccessResponse {
                Token = authResponse.Token,
            });
        }

        [HttpPost(ApiRoutes.Identity.Refresh)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthSuccessResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AuthFailResponse))]
        public async Task<IActionResult> Refresh() {
            string refreshToken = Request.Cookies["refreshToken"];
            var authResponse = await _identityService.RefreshTokenAsync(refreshToken);

            if (!authResponse.Success) {
                return BadRequest(new AuthFailResponse {
                    Errors = authResponse.Errors
                });
            }

            CookieOptions option = CookieProvider();
            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", authResponse.RefreshToken, option);
            

            return Ok(new AuthSuccessResponse {
                Token = authResponse.Token,
            });
        }

        [HttpPost(ApiRoutes.Identity.Logout)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthLogoutSuccessResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AuthFailResponse))]
        public async Task<IActionResult> Logout() {
            string refreshToken = Request.Cookies["refreshToken"];
            var authResponse = await _identityService.LogoutAsync(refreshToken);

            if (!authResponse.Success) {
                return BadRequest(new AuthFailResponse {
                    Errors = authResponse.Errors
                });
            }

            CookieOptions option = CookieProvider();
            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", "", option);

            return Ok(new AuthLogoutSuccessResponse{});
        }

        private CookieOptions CookieProvider() {
            return new CookieOptions {
                Expires = DateTime.UtcNow.AddMonths(6),
                HttpOnly = true,
                IsEssential = true,
                SameSite = SameSiteMode.Strict,
            };
        }
    }
}