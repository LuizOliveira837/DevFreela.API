using DevFreela.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.DisableUser
{
    public class DisableUserCommandHandler : IRequestHandler<DisableUserCommand, Unit>
    {
        public readonly IUserRepository _userRepository;
        public DisableUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(DisableUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DisableAsync(request.Id);

            return Unit.Value;


        }
    }
}
