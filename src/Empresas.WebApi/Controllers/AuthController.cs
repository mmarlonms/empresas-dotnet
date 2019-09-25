using Empresas.Domain.Services;
using Empresas.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Empresas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [HttpPost("/token")]
        public IActionResult Token([FromServices]  IAuthService authService, [FromForm] LoginModel loginModel)
        {
            var tokenResponse = authService.Authorize(loginModel.Username, loginModel.Password);
            return Ok(tokenResponse);
        }
    }
}