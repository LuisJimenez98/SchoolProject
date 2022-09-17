using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qualification.Api.Controllers.v1;
using Qualification.Application.Features.CreateQualificationCommand;
using Qualification.Application.Features.DeleteQualificationCommand;
using Qualification.Application.Features.Queries.GetAll;
using Qualification.Application.Features.Queries.GetById;
using Qualification.Application.Features.UpdateQualificationCommand;
using Qualification.Application.Parameters;

namespace Matter.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class QualificationController : BaseApiController
    {

        [HttpPost]
        public async Task<IActionResult> Create(CreateQualificationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateQualificationCommand command)
        {
            if (id != command.CalificacionId)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            return Ok(await Mediator.Send(new DeleteQualificationCommand() { CalificacionId = id }));
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetByIdQuery() { CalificacionId = id }));
        }

    }
}
