using POC.Cognito.Application.Users.Interfaces;
using POC.Cognito.Application.Users.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace POC.Cognito.Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplicationService _userApplicationService;

        public UserController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestModel loginRequestModel)
        {
            var response = await _userApplicationService.LoginAsync(loginRequestModel);

            return StatusCode((int)response.StatusCode,
               response.IsSuccess
               ? response.SuccessResponseModel
               : response.ErrorResponseModel);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> CreateUser(CreateUserRequestModel createUserRequestModel)
        {
            var response = await _userApplicationService.AddUserAsync(createUserRequestModel);

            return StatusCode((int)response.StatusCode,
                response.IsSuccess
                ? new { UserId = response.SuccessResponseModel }
                : response.ErrorResponseModel);
        }
        [HttpPost("recoverPassword")]
        public async Task<IActionResult> RecoverPassword(string username)
        {
            var response = await _userApplicationService.InitiateRecoverPassword(username);

            return StatusCode((int)response.StatusCode,
             response.IsSuccess
             ? response.SuccessResponseModel
             : response.ErrorResponseModel);
        }

        [HttpPost("recoverPasswordCode")]
        public async Task<IActionResult> ConfirmPasswordRecover(string username, string code, string newPassword)
        {

            var response = await _userApplicationService.ConfirmPasswordRecover(username, code, newPassword);

            return StatusCode((int)response.StatusCode,
                response.IsSuccess
                ? response.SuccessResponseModel
                : response.ErrorResponseModel);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userApplicationService.GetAllTeste();

            return Ok(response);
        }
    }
}
