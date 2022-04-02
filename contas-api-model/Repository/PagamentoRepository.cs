using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contas_api_model.Entity
{
    public class PagamentoRepository
    {
        public int Id { get; set; }
        public int Valor { get; set; }
        public virtual Conta Conta { get; set; }
    }
}
