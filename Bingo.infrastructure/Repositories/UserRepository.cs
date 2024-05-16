using Bingo.Core.Entities;
using Bingo.Core.Interfaces;
using Bingo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            _users = context.Set<User>();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _users.FindAsync(id);
        }

        public async Task AddUsers(User user)
        {
            _users.Add(user);
            await _context.SaveChangesAsync();
        }
    }

}
