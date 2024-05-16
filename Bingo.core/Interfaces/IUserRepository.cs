using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Core.Interfaces
{
    public interface IUserRepository<User> 

    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetById(int id);

        Task AddUsers(User entity);

        
    }
}
