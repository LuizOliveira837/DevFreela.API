using DevFreela.Core.DTO;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        public DevFreelaDbContext _context { get; set; }
        public UserRepository(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<IList<User>> GetAll()
        {
            var user = _context.Users;

            return user.ToList();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<int> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task UpdateAsync(UpdateUserDTO userDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userDto.Id);

            user.Update(userDto.FullName, userDto.Email);

            await _context.SaveChangesAsync();

        }

        public async Task DisableAsync(int id)
        {
            var user = await GetByIdAsync(id);

            user.Disable();

            await _context.SaveChangesAsync();

        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            var user = await _context
                .Users
                .Where(u => u.Email == email && u.Password == password)
                .SingleAsync();

            return user;
                
        }
    }
}
