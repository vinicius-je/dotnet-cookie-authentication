using CookieAuthSystem.Domain.Entities;

namespace CookieAuthSystem.Application.Features.Cookie
{
    public interface ICookieService
    {
        CookieDto GenerateCookie(User user);
    }
}
