using Matter.Application.Features.Commands.CreateMatterCommand;
using Matter.Application.Features.Commands.DeleteCreateMatterCommand;
using Matter.Application.Features.Commands.UpdateMatterCommand;
using Matter.Application.Features.Queries.GetAll;
using Matter.Application.Features.Queries.GetById;
using Matter.Application.Parameters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

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
        if(id != command.MateriaId)
            return BadRequest();

        return Ok(await Mediator.Send(command));
    }

    //DELETE api/controller/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteMatterCommand() { MateriaId = id}));
    }

    //GET api/controller
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
    {
        return Ok(await Mediator.Send(new GetAllQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    //GET api/controller/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { MateriaId = id }));
    }


}
