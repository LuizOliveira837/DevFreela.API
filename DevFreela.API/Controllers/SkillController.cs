using DevFreela.Application.Queries.SkillGetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        public readonly IMediator _mediator;
        public SkillController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var query = new SkillGetAllQuery();

            var skills = await _mediator.Send(query);

            return Ok(skills);
        }
    }
}
