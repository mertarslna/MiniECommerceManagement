using MiniECommerce.Entity.Entities;

namespace MiniECommerce.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}