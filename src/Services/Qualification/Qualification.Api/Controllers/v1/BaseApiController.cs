using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Qualification.Api.Controllers.v1;

[Route("api/v{version:ApiVersion}/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    private IMediator mediator;

    protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
}
