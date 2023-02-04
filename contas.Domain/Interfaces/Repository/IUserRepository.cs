using contas_api_model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contas_api_model.Interfaces
{
    public interface IUserRepository
    {
        Task Save(User user);

        Task Update(User newUser, int oldUserId);

        Task<User> Find(int id);

        Task<User> FindByEmail(string email);
    }
}
