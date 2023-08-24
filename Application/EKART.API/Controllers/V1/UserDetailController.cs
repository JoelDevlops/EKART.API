using EKART.API.Models.UserDetail;
using EKART.API.Queries.UserDetail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EKART.API.Controllers.V1
{

    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class UserDetailController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserDetailController(IMediator mediator) => this.mediator = mediator;

        [Authorize]
        [HttpGet("active/{IsActive:bool}")]
        [ProducesResponseType(200, Type = typeof(UserDetailListItem))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Authorize([FromRoute] bool IsActive, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetAllUserDetailQuery { IsActive = IsActive }, cancellationToken);
            return Ok(result);
        }


    }
}
