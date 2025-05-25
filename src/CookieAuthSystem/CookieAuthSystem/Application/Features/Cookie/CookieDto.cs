using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace CookieAuthSystem.Application.Features.Cookie
{
    public class CookieDto
    {
        public ClaimsIdentity Claims { get; private set; } = new();
        public AuthenticationProperties Properties { get; private set; } = new();

        public CookieDto(ClaimsIdentity claims, AuthenticationProperties properties)
        {
            Claims = claims;
            Properties = properties;
        }
    }
}
