using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Service.Abstraction.Contracts;
using Shared.DTO.IdentityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{


    [ApiController]
    [Route("api/[Controller]")]

    public class AuthenticationController(ISerivceMnager _serviceManger) : ControllerBase
    {


        [HttpPost("LogIn")]
        public async Task<UserResultDto> login([FromBody] LogInDto logInDto)
        {
            return await _serviceManger.AuthenticationService.LoginAsync(logInDto);
        }


        [HttpPost("Register")]
        public async Task<UserResultDto> Register([FromBody] RegisterDto registerDto)
        {

            return await _serviceManger.AuthenticationService.RegisterAsync(registerDto);
        }
    }
}