using System.Linq;
using Microsoft.AspNetCore.Http;

namespace fahlen_dev_webapi.Extensions
{
    public static class GeneralExtensions
    {
        public static string GetUserId(this HttpContext httpContext) {
            if (httpContext.User == null) {
                return string.Empty;
            }

            return httpContext.User.Claims.Single(x => x.Type == "id").Value;
        }
    }
}