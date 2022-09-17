using Matter.Application.Features.Commands.CreateMatterCommand;
using Matter.Application.Features.Commands.UpdateMatterCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Matter.Api.Controllers.v1;

[ApiVersion("1.0")]
public class MatterController : BaseApiController
{

    //POST api/controller
    [HttpPost]
    public async Task<IActionResult> Create(CreateMatterCommand command)
    {
        return Ok(await Mediator.Send(command));
    }


    //PUT api/controller
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateMatterCommand command)
    {
        if(id != command.MateriId)
            return BadRequest();

        return Ok(await Mediator.Send(command));
    }

}
