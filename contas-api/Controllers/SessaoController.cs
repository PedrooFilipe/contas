using contas_api_model.Entity;
using contas_api_model.Interfaces;
using contas_api_model.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contas_api.Controllers
{
    [Route("session")]
    public class SessaoController : ControllerBase
    {
        private IUserRepository _userRepository;
        public SessaoController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("login")]
        public async Task<RestResponse<User>> Login(User usuario)
        {
            RestResponse<User> restResponse = new RestResponse<User>();
            try
            {
                User user = await _userRepository.FindByEmailAndPassword(usuario.Email, usuario.Password);

                if (user != null && user.IsActive)
                {
                    restResponse.Message = "Success!";
                    restResponse.ResponseCode = 200;
                }
                else
                {
                    restResponse.Message = "User not found or inactive!";
                    restResponse.ResponseCode = 400;
                }
            }
            catch (Exception e)
            {
                restResponse.Message = "Erro na requisição!";
                restResponse.ResponseCode = 500;
            }

            return restResponse;
        }
    }
}
