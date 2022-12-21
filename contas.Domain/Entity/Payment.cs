using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contas_api_model.Entity
{
    [Serializable, Table("payments")]
    public class Payment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Amount { get; set; }

        [ForeignKey("Bill")]
        public int BillId { get; set; }

        public virtual Bill Bill { get; set; }
    }
}
