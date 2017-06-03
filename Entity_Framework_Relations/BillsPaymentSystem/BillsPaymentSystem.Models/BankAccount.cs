namespace BillsPaymentSystem.Models
{
    public class BankAccount : BillingDetail
    {
        public string BankName { get; set; }

        public string SWIFT { get; set; }
    }
}
