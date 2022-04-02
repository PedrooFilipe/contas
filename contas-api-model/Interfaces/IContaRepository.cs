using contas_api_model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contas_api_model.Interfaces
{
    public interface IContaRepository
    {
        Task Salvar(Conta conta);
        Task Alterar(Conta conta, int contaIdAntigo);
        void VerifyIfCanUpdate(Conta conta);
        Task<Conta> Procurar(int id);
    }
}
