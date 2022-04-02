using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace contas_api_model.Entity
{
    public class Parcela
    {
        public int Id { get; set; }

        public int NumeroParcela { get; set; }

        [ForeignKey("Conta")]
        public int ContaId { get; set; }

        [ForeignKey("Conta")]
        public int SituacaoParcelaId { get; set; }

        public virtual Conta Conta { get; set; }
        public virtual SituacaoParcela SituacaoParcela { get; set; }

    }
}
