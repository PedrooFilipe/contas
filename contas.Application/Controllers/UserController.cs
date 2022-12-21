using contas_api_model.Entity;
using contas_api_model.Interfaces;
using contas_api_model.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bills_api.Controllers;
using contas_api_model.DTO;

namespace contas_api.Controllers
{
    [Route("users")]
    public class UserController : MyController
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository iUserRepository)
        {
            _userRepository = iUserRepository;
        }

        [Route("save")]
        public async Task<RestResponse<User>> Save([FromHeader] string authorization, [FromBody] SaveUserDTO user)
        {
            RestResponse<User> restResponse = new RestResponse<User>();
            try
            {
                await _userRepository.Save(ConvertToUser(user));
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
