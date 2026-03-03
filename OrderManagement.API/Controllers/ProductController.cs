using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.UseCases.CreateProduct;

namespace OrderManagement.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly CreateProductHandler _createProductHandler;

        public ProductController(CreateProductHandler createProductHandler)
        {
            _createProductHandler = createProductHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var response = await _createProductHandler.Handle(request);
            return Ok(response);
        }
    }
}
