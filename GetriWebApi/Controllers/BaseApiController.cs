using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GetriWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator {
            get {
                return _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
            }
        }

        protected ActionResult HandleRequest<T>(Result<T> result) {
            if (result == null) {
                return NotFound();
            }
            if (result.IsSuccess && result.Value != null)
            {
                return Ok(result.Value);
            }
            if (result.IsSuccess && result.Value == null)
            {
                return NotFound();
            }
            return BadRequest();
        }
    }
}
