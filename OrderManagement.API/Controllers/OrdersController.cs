using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.UseCases.Orders.PlaceOrder;

namespace OrderManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        //private readonly PlaceOrderHandler _handler;
        private readonly IMediator _mediator;

        public OrdersController(/*PlaceOrderHandler handler*/
            IMediator mediator)
        {
            //_handler = handler;
            _mediator = mediator;
        }

        [HttpPost("PlaceOrder")]
        public async Task<IActionResult> PlaceOrder(PlaceOrderRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
