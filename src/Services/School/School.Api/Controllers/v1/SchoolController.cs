using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Application.Features.Commands.CreateSchoolCommand;
using School.Application.Features.Commands.DeleteSchoolCommand;
using School.Application.Features.Commands.UpdateSchoolCommand;
using School.Application.Features.Queries.GetAll;
using School.Application.Features.Queries.GetById;
using School.Application.Parameters;

namespace School.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SchoolController : BaseApiController
    {
        //POST api/controller
        [HttpPost]
        public async Task<IActionResult> Create(CreateSchoolCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        //GET api/controller
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] RequestParameter filter)
        {
            return Ok(await mediator.Send(new GetAllQuery() { PageNumber = filter.PageNumber, PageSize = filter.PageSize })); ;
        }

        //GET api/controller/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetByIdQuery() { ColegioId = id }));
        }


        //PUT api/controller
        [HttpPut("{id}")]
        public async Task<IActionResult> Create(int id, UpdateSchoolCommand command)
        {
            if (id != command.ColegioId)
                return BadRequest();

            return Ok(await mediator.Send(command));
        }


        //DELETE api/controller
        [HttpDelete("{id}")]
        public async Task<IActionResult> Create(int id)
        {
            return Ok(await mediator.Send(new DeleteSchoolCommand { ColegioId = id }));
        }
    }
}
