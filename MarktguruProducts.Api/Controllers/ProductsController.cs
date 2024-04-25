using MarktguruProducts.Application.Commands;
using MarktguruProducts.Application.Queries;
using MarktguruProducts.Application.Responses;
using MarktguruProducts.Application.Services.Interfaces;
using MarktguruProducts.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarktguruProducts.Api.Controllers
{
	[Authorize]
	[ApiController]
    [Route("[controller]")]
    public class ProductsController : ApiController
    {
        private readonly IMediator mediator;

		public ProductsController(IMediator mediator, IAuthenticationService authenticationService) : base(authenticationService)
		{
			this.mediator = mediator;
		}

		[HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery();

            var result = await this.mediator.Send(query);

            return Ok(result);
        }

        [HttpGet()]
        [AllowAnonymous]
        [Route("{productId:Guid}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var query = new GetProductQuery(productId);
            var result = await this.mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            CreateProductCommand createProductCommand = new CreateProductCommand(command.Product);

            var result = await this.mediator.Send(createProductCommand);

            return CreatedAtAction(nameof(GetProduct), new { productId = createProductCommand.Product.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            UpdateProductCommand updateProductCommand = new UpdateProductCommand(command.Product);
            var result = await this.mediator.Send(updateProductCommand);

            return result ? NoContent() : BadRequest();
        }

        [HttpDelete]
        [Route("{productId:Guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var command = new DeleteProductCommand(id);
            var result = await this.mediator.Send(command);

            return result ? NoContent() : BadRequest();
        }
    }
}
