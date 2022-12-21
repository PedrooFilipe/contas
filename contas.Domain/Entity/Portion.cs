using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace contas_api_model.Entity
{
    [Serializable, Table("portion")]
    public class Portion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int NumberPortion{ get; set; }

        [ForeignKey("Bill")]
        public int BillId { get; set; }

        [ForeignKey("StatusPortion")]
        public int StatusPortionId{ get; set; }

        public virtual Bill Bill { get; set; }

        public virtual StatusPortion StatusPortion { get; set; }

    }
}
