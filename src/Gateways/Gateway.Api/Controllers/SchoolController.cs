using Api.Gateway.Application.Behaviors.Commands.School;
using Api.Gateway.Application.Behaviors.Queries.School;
using Api.Gateway.Application.Parameters;
using Api.Gateway.Application.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolProxy _schoolProxy;

        public SchoolController(ISchoolProxy schoolProxy)
        {
            _schoolProxy = schoolProxy;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSchoolCommand command)
        {
            return Ok(await _schoolProxy.CreateAsync(command));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
        {
            return Ok(await _schoolProxy.GetAllAsync(new GetAllQuery() { PageNumber = filter.PageNumber, PageSize = filter.PageSize })); ;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _schoolProxy.GetByIdAsync(new GetByIdQuery() { ColegioId = id }));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateSchoolCommand command)
        {
            if (id != command.ColegioId)
                return BadRequest();

            return Ok(await _schoolProxy.UdateAsync(command));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _schoolProxy.DeleteAsync(new DeleteSchoolCommand { ColegioId = id }));
        }
    }
}
