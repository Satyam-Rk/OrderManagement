using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.UseCases.LoginUser;
using OrderManagement.Application.UseCases.RegisterUser;

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly RegisterUserHandler _registerUserHandler;
        //private readonly LoginUserHandler _loginUserHandler;
        private readonly IMediator _mediator;

        public UsersController(/*RegisterUserHandler registerUserHandler,*/
            //LoginUserHandler loginUserHandler,
            IMediator mediator)
        {
            //_registerUserHandler = registerUserHandler;
            //_loginUserHandler = loginUserHandler;
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("secure-test")]
        public IActionResult SecureTest()
        {
            return Ok("You are authenticated.");
        }
    }
}
