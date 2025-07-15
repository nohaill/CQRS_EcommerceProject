using Ecommerce.Application.Commands.Products;
using Ecommerce.Application.Queries.Products;
using Ecommerce.Domain.Dtos.Product;
using Ecommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _mediator.Send(new GetAllProductsQuery());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery { Id = id });

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddProduct entity)
        {
            

            var newProductId = await _mediator.Send(new CreateProductCommand { Product = entity});

            return CreatedAtAction(nameof(GetById), new { id = newProductId }, new { id = newProductId });

        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProduct product)
        {
            var success = await _mediator.Send(new UpdateProductCommand{ Product = product });

            if (!success)
                return NotFound();

            return Ok("Updated");
        }


    }
}
