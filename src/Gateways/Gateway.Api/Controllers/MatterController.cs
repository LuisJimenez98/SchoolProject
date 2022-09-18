using Api.Gateway.Application.Behaviors.Commands.Matter;
using Api.Gateway.Application.Behaviors.Queries;
using Api.Gateway.Application.Parameters;
using Api.Gateway.Application.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatterController : ControllerBase
    {
        private readonly IMatterProxy _matterProxy;

        public MatterController(IMatterProxy matterProxy)
        {
            _matterProxy = matterProxy;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMatterCommand command)
        {
            return Ok(await _matterProxy.CreateAsync(command));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
        {
            return Ok(await _matterProxy.GetAllAsync(new GetAllQuery() { PageNumber = filter.PageNumber, PageSize = filter.PageSize })); ;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _matterProxy.GetByIdAsync(new GetByIdQuery() { Id = id }));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateMatterCommand command)
        {
            if (id != command.MateriaId)
                return BadRequest();

            return Ok(await _matterProxy.UdateAsync(command));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _matterProxy.DeleteAsync(new DeleteMatterCommand { MateriaId = id }));
        }
    }
}
