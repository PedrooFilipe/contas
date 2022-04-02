using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contas.Entidades
{
    public class ContaReceber
    {
        public int Id { get; set; }
        public string ClienteId { get; set; }
        public string ValorTotal { get; set; }
        public string ValorTotalDesconto { get; set; }
        public string ValorDesconto { get; set; }
        public int Parcelas { get; set; }
        public float Juros { get; set; }
    }
}
