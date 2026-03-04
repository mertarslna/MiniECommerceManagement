using MiniECommerce.Business.Helpers;
using MiniECommerce.Business.Interfaces;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Concrete
{
    public class UserManager : IUserService
    {
        // Adding, listing, updating and deleting functions for users
        private readonly IUserRepository _repository;

        public UserManager(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<User>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<User> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid user ID.");

            var user = await _repository.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException("User not found.");

            return user;
        }
        public async Task AddAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null.");

            string hashedPassword = PasswordHelper.HashPassword(user.Password);
            user.Password = hashedPassword;

            await _repository.AddAsync(user);
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateAsync(User user)
        {

            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null.");

            if (await _repository.GetByIdAsync(user.Id) == null)
                throw new KeyNotFoundException("User not found.");

            _repository.Update(user);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid user ID.");

            var user = await _repository.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException("User not found.");

            _repository.Delete(user);
            await _repository.SaveChangesAsync();
        }
    }
}