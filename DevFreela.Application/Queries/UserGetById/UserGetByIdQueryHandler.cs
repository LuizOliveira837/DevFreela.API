using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.UserGetById
{
    public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQuery, UserViewModel>
    {
        public readonly IUserRepository _userRepository;
        public UserGetByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserViewModel> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            var userViewModel = new UserViewModel(
                user.FullName
                ,user.Email
                ,user.BirthDate
                ,user.Active
                ,user.Skills
                ,user.OwnedProjects
                ,user.FreelanceProjects);

            return userViewModel;
        }
    }
}
