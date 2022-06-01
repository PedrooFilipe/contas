using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contas_api_model.Entity
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int Valor { get; set; }
        public virtual Bill Bill { get; set; }
    }
}
