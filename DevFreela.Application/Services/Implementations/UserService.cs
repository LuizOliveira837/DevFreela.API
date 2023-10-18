using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        public UserService(DevFreelaDbContext dbContext, IUserRepository userRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
        }
        public void Disable(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            user.Disable();
            _dbContext.SaveChanges();
        }

        public void Create(NewUserInputModel input)
        {
            var user = new User(input.FullName, input.Email, input.BirthDate);

            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();
        }

        public IList<UserViewModel> GetAll()
        {
            var users = _dbContext.Users
                .Select(u => new UserViewModel(u.FullName, u.Email, u.BirthDate, u.Active, u.Skills, u.OwnedProjects, u.FreelanceProjects))
                .ToList();

            return users;
        }


    }
}
