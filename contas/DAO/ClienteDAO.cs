using contas.Entidades;
using contas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contas.DAO
{
    public class ClienteDAO : IClienteDAO
    {

        public List<Cliente> List(string nome, string sort, bool desc)
        {
            throw new NotImplementedException();
        }

        public Cliente Save(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente Find(int clienteId)
        {
            throw new NotImplementedException();
        }

        public Cliente Update(Cliente newCliente)
        {
            throw new NotImplementedException();
        }

        public void Delete(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
