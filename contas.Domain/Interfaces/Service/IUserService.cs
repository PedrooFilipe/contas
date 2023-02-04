using contas_api_model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contas_api_model.Interfaces.Service
{
    public interface IUserService
    {
        Task SaveAsync(User user);

    }
}
