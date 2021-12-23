using Core.Models;
using IMS.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authorizationService)
        {
            _authService = authorizationService;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginModel loginModel)
        {
            var result = await _authService.ValidateUserAsync(loginModel.Email, loginModel.Password);
            if (result==null)
                return Unauthorized();
            return Ok(new { token = result });
        }
    }
}
