using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories.Implementation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.UserGetAll
{
    public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, IList<UserViewModel>>
    {
        public readonly IUserRepository _userRepository;
        public UserGetAllQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public async Task<IList<UserViewModel>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();

            var usersViewodel = users
                .Select(u => new UserViewModel(u.FullName, u.Email, u.BirthDate, u.Active,u.Skills, u.OwnedProjects, u.FreelanceProjects))
                .ToList();

            return usersViewodel;



        }

       
    }
}
