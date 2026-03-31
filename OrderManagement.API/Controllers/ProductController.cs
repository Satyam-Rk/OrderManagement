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
        private readonly CreateProductHandler _createProductHandler;
        private readonly GetProductByIdHandler _getProductByIdHandler;
        private readonly GetAllProductsHandler _getAllProductsHandler;
        private readonly UpdateProductHandler _updateProductHandler;
        private readonly DeleteProductHandler _deleteProductHandler;

        public ProductController(CreateProductHandler createProductHandler,
            GetProductByIdHandler getProductByIdHandler,
            GetAllProductsHandler getAllProductsHandler,
            UpdateProductHandler updateProductHandler,
            DeleteProductHandler deleteProductHandler)
        {
            _createProductHandler = createProductHandler;
            _getProductByIdHandler = getProductByIdHandler;
            _getAllProductsHandler = getAllProductsHandler;
            _updateProductHandler = updateProductHandler;
            _deleteProductHandler = deleteProductHandler;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var response = await _createProductHandler.Handle(request);
            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var request = new GetProductByIdRequest { Id = id };
            var result = await _getProductByIdHandler.Handle(request);

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

            var result = await _getAllProductsHandler.Handle(request);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            var result = await _updateProductHandler.Handle(request);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var request = new DeleteProductRequest { Id = id };
            var result = await _deleteProductHandler.Handle(request);

            return Ok(result);
        }
    }
}
