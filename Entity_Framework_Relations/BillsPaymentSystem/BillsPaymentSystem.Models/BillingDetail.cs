using System.ComponentModel.DataAnnotations.Schema;

namespace BillsPaymentSystem.Models
{
    public class BillingDetail
    {
        [ForeignKey("Owner")]
        public int Id { get; set; }

        public string Number { get; set; }

        public virtual User Owner { get; set; }
    }
}
