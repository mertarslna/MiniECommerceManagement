using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Services.Interfaces
{
    public interface IUserService
    {
        // Adding, listing, updating, deleting and soft deleting functions for categories
        List<User> GetAll();
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}