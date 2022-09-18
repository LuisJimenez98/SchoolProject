using Api.Gateway.Application.Behaviors.Commands.Qualification;
using Api.Gateway.Application.Behaviors.Queries;
using Api.Gateway.Application.Parameters;
using Api.Gateway.Application.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationProxy _qualificationProxy;

        public QualificationController(IQualificationProxy qualificationProxy)
        {
            _qualificationProxy = qualificationProxy;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQualificationCommand command)
        {
            return Ok(await _qualificationProxy.CreateAsync(command));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
        {
            return Ok(await _qualificationProxy.GetAllAsync(new GetAllQuery() { PageNumber = filter.PageNumber, PageSize = filter.PageSize })); ;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _qualificationProxy.GetByIdAsync(new GetByIdQuery() { Id = id }));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateQualificationCommand command)
        {
            if (id != command.CalificacionId)
                return BadRequest();

            return Ok(await _qualificationProxy.UpdateAsync(command));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _qualificationProxy.DeleteAsync(new DeleteQualificationCommand { CalificacionId = id }));
        }
    }
}
