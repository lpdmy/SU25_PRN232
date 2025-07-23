using DataAccess.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
            => await _userRepo.GetAllAsync();

        public async Task<User?> GetByIdAsync(int id)
            => await _userRepo.GetByIdAsync(id);

        public async Task<User?> GetByEmailAsync(string email)
            => await _userRepo.GetByEmailAsync(email);

        public async Task CreateAsync(User user)
        {
            var existingUser = await _userRepo.GetByEmailAsync(user.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Email already exists.");
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            await _userRepo.AddAsync(user);
        }


        public async Task UpdateAsync(User user)
            => await _userRepo.UpdateAsync(user);

        public async Task DeleteAsync(int id)
            => await _userRepo.DeleteAsync(id);
    }

}
