using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.UseCases.Products.CreateProduct;
using OrderManagement.Application.UseCases.Products.DeleteProduct;
using OrderManagement.Application.UseCases.Products.GetAllProducts;
using OrderManagement.Application.UseCases.Products.GetProductById;
using OrderManagement.Application.UseCases.Products.UpdateProduct;

namespace OrderManagement.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        //private readonly CreateProductHandler _createProductHandler;
        //private readonly GetProductByIdHandler _getProductByIdHandler;
        //private readonly GetAllProductsHandler _getAllProductsHandler;
        //private readonly UpdateProductHandler _updateProductHandler;
        //private readonly DeleteProductHandler _deleteProductHandler;
        private readonly IMediator _mediator;

        public ProductController(/*CreateProductHandler createProductHandler,*/
            //GetProductByIdHandler getProductByIdHandler,
            //GetAllProductsHandler getAllProductsHandler,
            //UpdateProductHandler updateProductHandler,
            //DeleteProductHandler deleteProductHandler,
            IMediator mediator)
        {
            //_createProductHandler = createProductHandler;
            //_getProductByIdHandler = getProductByIdHandler;
            //_getAllProductsHandler = getAllProductsHandler;
            //_updateProductHandler = updateProductHandler;
            //_deleteProductHandler = deleteProductHandler;
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var request = new GetProductByIdRequest { Id = id };
            var result = await _mediator.Send(request);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var request = new GetAllProductsRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var request = new DeleteProductRequest { Id = id };
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
