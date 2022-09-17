using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qualification.Api.Controllers.v1;
using Qualification.Application.Features.CreateQualificationCommand;

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

    }
}
