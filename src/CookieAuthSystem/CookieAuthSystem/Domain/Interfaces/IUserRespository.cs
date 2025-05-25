using CookieAuthSystem.Domain.Entities;

namespace CookieAuthSystem.Domain.Interfaces
{
    public interface IUserRespository
    {
        Task<User?> GetByEmail(string email);
        Task Create(User user); 
        Task Update(User user);
    }
}
