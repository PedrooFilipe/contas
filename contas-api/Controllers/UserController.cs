using contas_api_model.Entity;
using contas_api_model.Interfaces;
using contas_api_model.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contas_api_model.DTO;

namespace contas_api.Controllers
{
    [Route("users")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository iUserRepository)
        {
            _userRepository = iUserRepository;
        }

        [Route("save")]
        public async Task<RestResponse<User>> Save(SaveUserDTO user)
        {
            RestResponse<User> restResponse = new RestResponse<User>();
            try
            {
                await _userRepository.Save(ConvertToUser(user));
                restResponse.Message = "Sucesso!";
                restResponse.ResponseCode = 200;
            }
            catch (Exception e)
            {
                restResponse.Message = "Erro na requisição!";
                restResponse.ResponseCode = 500;
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
