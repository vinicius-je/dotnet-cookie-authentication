using CookieAuthSystem.Domain.Entities;
using CookieAuthSystem.Domain.Interfaces;

namespace CookieAuthSystem.Application.Features.Login
{
    public class LoginService : ILoginService
    {
        protected readonly IUserRespository _respository;

        public LoginService(IUserRespository respository)
        {
            _respository = respository;
        }

        public async Task<TResult<User>> Login(LoginDto dto)
        {
            var result = new TResult<User>();
            var user = await _respository.GetByEmail(dto.Email);

            if (user == null)
            {
                result.AddError($"User {dto.Email} not found!");
                return result;
            }

            if (!user.IsPasswordMatch(dto.Password))
            {
                result.AddError($"Password Incorrect!");
                return result;
            }

            return result;
        }
    }
}
