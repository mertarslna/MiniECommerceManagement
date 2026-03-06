using MiniECommerce.Business.DTOs.Auth;
using MiniECommerce.Business.Interfaces;
using MiniECommerce.DataAccess.Helpers;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;
using MiniECommerce.Entity.Enums;

namespace MiniECommerce.Business.Services
{
    public class AuthManager : IAuthService
    {
        private readonly IUserRepository _repository;
        private readonly IJwtService _jwtService;

        public AuthManager(IUserRepository repository, IJwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            var existing = await _repository.GetByEmailAsync(dto.Email);
            if (existing != null)
                throw new Exception("Bu email zaten kayıtlı.");

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = PasswordHelper.HashPassword(dto.Password),
                IsActive = true,
                UserType = UserType.Customer,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            await _repository.AddAsync(user);
            await _repository.SaveChangesAsync();

            return await _jwtService.GenerateToken(user);
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _repository.GetByEmailAsync(dto.Email);

            if (user == null || !PasswordHelper.VerifyPassword(dto.Password, user.Password))
                throw new UnauthorizedAccessException("Email veya şifre hatalı.");

            if (!user.IsActive)
                throw new UnauthorizedAccessException("Hesabınız aktif değil.");

            return await _jwtService.GenerateToken(user);
        }
    }
}