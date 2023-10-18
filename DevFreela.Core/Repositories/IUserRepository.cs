using DevFreela.Core.DTO;
using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        public Task<IList<User>> GetAll();
        public Task<User> GetByIdAsync(int id);
        public Task<int> CreateAsync(User user);
        public Task UpdateAsync(UpdateUserDTO user);
        public Task DisableAsync(int id);
        
    }
}
