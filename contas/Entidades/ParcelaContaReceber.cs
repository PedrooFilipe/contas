using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contas.Entidades
{
    public class ParcelaContaReceber
    {

        public int Id { get; set; }
        public string ContaReceberId { get; set; }
        public float ValorTotal { get; set; }
        public float ValorTotalDesconto { get; set; }
        public float ValorDesconto { get; set; }
        public float Juros { get; set; }
    }
}
