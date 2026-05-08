using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.UseCases.Orders.PlaceOrder;

namespace OrderManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly PlaceOrderHandler _handler;

        public OrdersController(PlaceOrderHandler handler)
        {
            _handler = handler;
        }

        [HttpPost("PlaceOrder")]
        public async Task<IActionResult> PlaceOrder(PlaceOrderRequest request)
        {
            var result = await _handler.Handle(request);

            return Ok(result);
        }
    }
}
