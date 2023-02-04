using contas_api_model.Entity;
using contas_api_model.Interfaces;
using contas_api_model.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contas_api_model.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task SaveAsync(User user)
        {
            User userEmail = await _userRepository.FindByEmail(user.Email);

            if(userEmail != null)
            {
                throw new Exception("Já existe um usuário com o email informado");
            }

            await _userRepository.Save(user);
        }


    }
}
