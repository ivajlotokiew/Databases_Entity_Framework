using System.ComponentModel.DataAnnotations.Schema;

namespace BillsPaymentSystem.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual BillingDetail BillingDetails { get; set; }
    }
}
