using contas_api_model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace contas_api.Interfaces
{
    public interface IContaService
    {
        Task Salvar(Conta conta);
        Task Alterar(Conta conta);
        Task Excluir(Conta conta);
        Task<Conta> Procurar(Conta conta);
        Task<List<Conta>> Listar(Conta conta);
    }
}
