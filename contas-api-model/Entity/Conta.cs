using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contas_api_model.Entity
{
    public class Conta
    {
        public int Id { get; set; }
        public float ValorTotal { get; set; }
        public float ValorRestante { get; set; }
        public int? NumeroParcelas { get; set; }
        public DateTime DataValidade { get; set; }

        [ForeignKey("FormaPagamento")]
        public int FormaPagamentoId { get; set; }

        public virtual FormaPagamento FormaPagamento { get; set; }
    }
}
