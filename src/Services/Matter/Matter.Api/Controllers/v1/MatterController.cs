using Matter.Application.Features.Commands;
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

}
