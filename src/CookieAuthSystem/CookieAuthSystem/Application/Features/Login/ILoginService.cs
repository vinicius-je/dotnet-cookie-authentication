using CookieAuthSystem.Domain.Entities;

namespace CookieAuthSystem.Application.Features.Login
{
    public interface ILoginService
    {
        Task<TResult<User>> Login(LoginDto dto);
    }
}
