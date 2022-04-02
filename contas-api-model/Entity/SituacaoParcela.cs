using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace contas_api_model.Entity
{
    public class SituacaoParcela
    {
        public int Id { get; set; }

        public int Descricao { get; set; }
    }
}
