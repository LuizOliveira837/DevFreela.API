using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.UpdateUser;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.UserGetAll;
using DevFreela.Application.Queries.UserGetById;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly IUserService _userService;
        private readonly IMediator _mediator;

        public UserController(DevFreelaDbContext dbContext, IUserService userService, IMediator mediator)
        {
            _dbContext = dbContext;
            _userService = userService;
            _mediator = mediator;


        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var user = await  _mediator.Send(new UserGetAllQuery());
            return Ok(user);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var user = await _mediator.Send(new UserGetByIdQuery(id));

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUserCommand input)
        {
            var id = await _mediator.Send(input);

            return CreatedAtAction(nameof(GetById), new { id = id }, input);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromBody] UpdateUserInputModel input)
        {
            await _mediator.Send(new UpdateUserCommand(id, input.FullName, input.Email));
            return NoContent();
        }



    }
}
