using Shared.DTO.IdentityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction.Contracts
{
    public interface IAuthenticationService
    {
        //LogIn  retrun UserResultDto[Display,Token,Email]==>Take Parameters  [Email,Password]


        public Task<UserResultDto> LoginAsync(LogInDto logInDto);



        //Register  retrun   UserResultDto[Display,Token,Email]==> Take Parmeters  [Email,Password,PhoneNumber,DisplayName ]

        public Task<UserResultDto> RegisterAsync(RegisterDto registerDto);

    }
}
