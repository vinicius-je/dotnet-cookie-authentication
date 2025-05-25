using CookieAuthSystem.Domain.Entities;
using CookieAuthSystem.Domain.Interfaces;
using CookieAuthSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CookieAuthSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRespository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(AppDbContext context)
        {
            _context = context;
            _users = _context.Set<User>();
        }

        public async Task Create(User user)
        {
            await _users.AddAsync(user);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _users
                .Where(x => x.Email == email)
                .Include(x => x.Roles)
                .FirstOrDefaultAsync();
        }

        public async Task Update(User user)
        {
            await Task.FromResult(_users.Update(user));
        }
    }
}
