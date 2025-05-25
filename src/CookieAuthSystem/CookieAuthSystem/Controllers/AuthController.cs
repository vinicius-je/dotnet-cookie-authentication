using CookieAuthSystem.Application.Features.Cookie;
using CookieAuthSystem.Application.Features.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CookieAuthSystem.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        protected readonly ILoginService _loginService;
        protected readonly ICookieService _cookieService;

        public AuthController(ILoginService loginService, ICookieService cookieService)
        {
            _loginService = loginService;
            _cookieService = cookieService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var userResult = await _loginService.Login(request);

            // Check if login is successful
            if (!userResult.IsSuccess || userResult.Value == null)
            {
                return BadRequest(userResult.ErrorMessage);
            }

            var cookie = _cookieService.GenerateCookie(userResult.Value);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(cookie.Claims),
                cookie.Properties);

            return LocalRedirect("/logged");
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("User Logout Successful");
        }

        [Authorize]
        [HttpGet("/logged")]
        public IActionResult Logged()
        {
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;

            return Ok($"Hello {userName}");
        }
    }
}
