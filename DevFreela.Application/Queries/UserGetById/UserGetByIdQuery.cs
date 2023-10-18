using DevFreela.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.UserGetById
{
    public class UserGetByIdQuery : IRequest<UserViewModel>
    {
        public int Id { get; }
        public UserGetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
