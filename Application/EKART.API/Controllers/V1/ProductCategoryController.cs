using EKART.API.Commamds.Categories;
using EKART.API.Models.Category;
using EKART.API.Models.UserDetail;
using EKART.API.Queries.Categories;
using EKART.API.Queries.UserDetail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EKART.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductCategoryController(IMediator mediator) => this.mediator = mediator;

        [Authorize]
        [HttpGet("active/{IsActive:bool}")]
        [ProducesResponseType(200, Type = typeof(ProductCategoryListItem))]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Authorize([FromRoute] bool IsActive, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetAllProductCategoryQuery { IsActive = IsActive }, cancellationToken);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("create-product-category")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateProductCategory([FromBody] CreateProductCategoryCommand createProductCategoryCommand, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(createProductCategoryCommand, cancellationToken);
            return Ok(result);
        }

        [Authorize]
        [HttpPut("update-product-category")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult>UpdateProductCategory([FromBody] UpdateProductCategoryCommand updateProductCategoryCommand, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(updateProductCategoryCommand, cancellationToken);
            return Ok(result);
        }
    }
}
