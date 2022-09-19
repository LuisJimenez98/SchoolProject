using Api.Gateway.Application.Behaviors.Commands.User;
using Api.Gateway.Application.Behaviors.Queries;
using Api.Gateway.Application.Parameters;
using Api.Gateway.Application.Proxies;
using Api.Gateway.Application.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserProxy _userProxy;

        public UserController(IUserProxy userProxy)
        {
            _userProxy = userProxy;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            return Ok(await _userProxy.CreateAsync(command));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
        {
            return Ok(await _userProxy.GetAllAsync(new GetAllQuery() { PageNumber = filter.PageNumber, PageSize = filter.PageSize })); ;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userProxy.GetByIdAsync(new GetByIdQuery() { Id = id }));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserCommand command)
        {
            if (id != command.UsuarioId)
                return BadRequest();

            return Ok(await _userProxy.UpdateAsync(command));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _userProxy.DeleteAsync(new DeleteUserCommand { UsuarioId = id }));
        }

    }
}
