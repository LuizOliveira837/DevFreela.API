using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries;
using DevFreela.Application.Queries.ProjectGetAll;
using DevFreela.Application.Queries.ProjectGetById;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        public readonly DevFreelaDbContext _dbContext;
        public readonly IProjectService _projectService;

        public readonly IMediator _mediator;

        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new ProjectGetAllQuery();
            var projects = await _mediator.Send(query);

            return Ok(projects);
        }
 

        [HttpGet("/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new ProjectGetByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand inputModel)
        {

            //  var projectId = _projectService.Create(inputModel);

            var id = await _mediator.Send(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand inputModel)
        {
            var project =  _projectService.GetById(id);

            if (project == null) return NotFound();

            await _mediator.Send(inputModel);

            return NoContent();


        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var project = _projectService.GetById(id);

            if (project == null) return NotFound();

            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();


        }


        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand createCommentInputModel)
        {
            var project = _projectService.GetById(id);

            if (project == null) return NotFound();

            await _mediator.Send(createCommentInputModel);

            return NoContent();


        }

        [HttpPut("{id}/Start")]
        public async Task<IActionResult> Start(int id)
        {
            var project = _projectService.GetById(id);

            if (project == null) return NotFound();

            var command = new StartProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/Finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var project = _projectService.GetById(id);

            if (project == null) return NotFound();

            var command = new FinishProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
