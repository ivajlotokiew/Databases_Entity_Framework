using System;

namespace BillsPaymentSystem.Models
{
    public class CreditCard : BillingDetail
    {
        public string CardType { get; set; }

        public DateTime? ExpirationMonth { get; set; }

        public DateTime? ExpirationYear { get; set; }
    }
}
