using contas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contas.Interfaces
{
    public interface IClienteDAO
    {
        List<Cliente> List(string nome, string sort, bool desc);
        Cliente Save(Cliente cliente);
        Cliente Find(int clienteId);
        Cliente Update(Cliente newCliente);
        void Delete(Cliente cliente);
    }
}
