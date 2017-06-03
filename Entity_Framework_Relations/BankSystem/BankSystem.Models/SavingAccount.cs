using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models
{
    [Table("SavingAccounts")]
    public class SavingAccount : Account
    {
        private double interestRate;

        public SavingAccount()
            : base()
        {
            this.InterestRate = 0;
        }

        public double InterestRate
        {
            get { return this.interestRate; }
            set { this.interestRate = value; }
        }

        public void AddInterest()
        {
            this.InterestRate += 1.3;
        }
    }
}
