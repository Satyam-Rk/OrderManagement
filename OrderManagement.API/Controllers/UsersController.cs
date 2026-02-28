using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.UseCases.RegisterUser;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly RegisterUserHandler _registerUserHandler;

        public UsersController(RegisterUserHandler registerUserHandler)
        {
            _registerUserHandler = registerUserHandler;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var response = await _registerUserHandler.Handle(request);
            return Ok(response);
        }
    }
}
