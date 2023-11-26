using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        public IUserRepository _repository { get; set; }
        public IAuthService _authService { get; set; }

        public LoginUserCommandHandler(IAuthService authService, IUserRepository repository)
        {
            _repository = repository;
            _authService = authService;
        }


        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordEncripty = _authService.ComputerSha256Hash(request.Password);

            var user = await _repository.GetUserByEmailAndPasswordAsync(request.Email, passwordEncripty);

            if (user == null) throw new Exception("Usuario não encontrado");

            return new LoginUserViewModel(user.Email, _authService.GenerationJwtToken(user.Email, "1"));


        }
    }
}
