using contas_api_model.Entity;
using contas_api_model.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using bills_api.Controllers;
using contas_api_model.DTO;
using contas_api_model.Interfaces.Service;

namespace contas_api.Controllers
{
    [Route("users")]
    public class UserController : MyController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("save")]
        public async Task<RestResponse<User>> Save([FromHeader] string authorization, [FromBody] SaveUserDTO user)
        {
            RestResponse<User> restResponse = new RestResponse<User>();
            try
            {
                await _userService.SaveAsync(ConvertToUser(user));
                restResponse = this.GetRestResponseOk<User>(null, null, authorization);
            }
            catch (Exception e)
            {
                restResponse = this.GetRestResponseError<User>(authorization);
            }

            return restResponse;
        }
        
        public User ConvertToUser(SaveUserDTO saveUserDto)
        {
            return new User
            {
                Name = saveUserDto.Name,
                Email = saveUserDto.Email,
                Password = saveUserDto.Password
            };
        }
    }
}
