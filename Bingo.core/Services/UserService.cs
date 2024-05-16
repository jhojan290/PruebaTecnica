using Bingo.Core.Entities;
using Bingo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _userRepository;
        public UserService(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User> GetUser(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task InsertUser(User user)
        {
            await _userRepository.AddUsers(user);
        }

       
    }
}
