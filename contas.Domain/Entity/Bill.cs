using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contas_api_model.Entity
{
    [Serializable, Table("bills")]
    public class Bill
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public float TotalAmount { get; set; }

        public float RemainingAmount { get; set; }

        public int? PortionCount { get; set; }

        public DateTime ExpirationDate { get; set; }

        [ForeignKey("TypePayment")]
        public int TypePaymentId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("BillType")]
        public int BillTypeId { get; set; }

        public virtual TypePayment TypePayment { get; set; }

        public virtual User User { get; set; }

        public virtual List<Portion> Portions { get; set; }

        public virtual BillType BillType { get; set; }

    }
}
