using EKART.API.Models.Authorization;
using EKART.API.Queries.Authorization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EKART.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    
    public class AuthorizeController : ControllerBase
    {
        private IMediator mediator;

        public AuthorizeController(IMediator mediator) => this.mediator = mediator;

        [HttpPost("authorize")]
        [ProducesResponseType(200, Type = typeof(TokenWithRolesListItem))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Authorize([FromBody] AuthorizationQuery authorizationQuery, CancellationToken cancellationToken )
        {
            var result = await mediator.Send(authorizationQuery, cancellationToken);
            if (result.Roles == null)
            return Unauthorized();
            return Ok(result);
        }
        [HttpPost("get-refresh-token")]
        [ProducesResponseType(200, Type = typeof(TokenWithRolesListItem))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> RefreshToken([FromBody] ReloadRefreshTokenQuery refreshTokenQuery, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(refreshTokenQuery, cancellationToken);
            return Ok(result);
        }

    }
}
