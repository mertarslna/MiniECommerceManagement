using Microsoft.EntityFrameworkCore;
using MiniECommerce.DataAccess.Context;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.DataAccess.Repositories.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
        // MiniECommerce.DataAccess/Repositories/UserRepository.cs
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
