using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace contas_api_model.Entity
{
    [Serializable, Table("statusPortion")]
    public class StatusPortion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Description { get; set; }

    }
}
