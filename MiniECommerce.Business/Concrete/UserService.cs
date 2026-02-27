using MiniECommerce.Business.Services.Interfaces;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Services.Concrete
{
    public class UserService : IUserService
    {
        // Adding, listing, updating and deleting functions for users
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public List<User> GetAll() { return _repository.GetAll(); }
        public User GetById(int id) { return _repository.GetById(id); }
        public void Add(User user) { _repository.Add(user); }
        public void Update(User user) { _repository.Update(user); }
        public void Delete(int id) { _repository.Delete(_repository.GetById(id)); }
    }
}