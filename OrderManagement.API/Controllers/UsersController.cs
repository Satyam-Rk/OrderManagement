using FluentValidation;
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
        private readonly RegisterUserHandler _registerUserHandler;
        private readonly LoginUserHandler _loginUserHandler;

        public UsersController(RegisterUserHandler registerUserHandler,
            LoginUserHandler loginUserHandler)
        {
            _registerUserHandler = registerUserHandler;
            _loginUserHandler = loginUserHandler;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var response = await _registerUserHandler.Handle(request);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            var response = await _loginUserHandler.Handle(request);
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
