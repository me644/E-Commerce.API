using Domain.Entites.IdentityModule;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Service.Abstraction.Contracts;
using Shared.DTO.IdentityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class AuthenticationService(UserManager<User> _userManager) : IAuthenticationService
    {
        public async Task<UserResultDto> LoginAsync(LogInDto logInDto)
        {
            //check Exsistance of email
            var user =  await _userManager.FindByEmailAsync(logInDto.Email);
            if (user == null) { throw new UnAuthorizedExceptions(); }
          var result = await _userManager.CheckPasswordAsync(user, logInDto.Password);
            //  interanlly  call funcation  {_passwordHasher.VerifyHashedPassword(user,Passsowrd)}  for  check  hash IN db  and  password
            //come from  logIn
            if (!result) { throw new UnAuthorizedExceptions(); }
            
            return new UserResultDto() {DisplayName=user.DisplayName,Email=user.Email};
        }

        public async Task<UserResultDto> RegisterAsync(RegisterDto registerDto)
        {

            User user = new User()
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                UserName = registerDto.UserName
            };

            var  result=  await  _userManager.CreateAsync(user,registerDto.Password);

           
            if (!result.Succeeded) { 
            
              var  errors=result.Errors.Select(m=>m.Description).ToList();
                 throw  new ValidationExceptions(errors);
            
            }
            return new UserResultDto { DisplayName = user.DisplayName, Email = user.Email, Tooken = "ee" };
        }
    }
}
