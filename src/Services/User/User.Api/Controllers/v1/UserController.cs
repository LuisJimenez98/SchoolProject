using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.Features.Commands.CreateUserCommand;
using User.Application.Features.Commands.DeleteUserCommand;
using User.Application.Features.Commands.UpdateUserCommand;
using User.Application.Features.Queries.GetAll;
using User.Application.Features.Queries.GetById;
using User.Application.Parameters;

namespace User.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {
        //POST api/controller
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        //PUT api/controller
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserCommand command)
        {
            if (id != command.UsuarioId)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        //DELETE api/controller/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand() { UsuarioId = id }));
        }

        //GET api/controller
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllQuery() { PageNumber = filter.PageNumber, PageSize = filter.PageSize })); ;
        }

        //GET api/controller/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetByIdQuery() { UsuarioId = id }));
        }
    }
}
