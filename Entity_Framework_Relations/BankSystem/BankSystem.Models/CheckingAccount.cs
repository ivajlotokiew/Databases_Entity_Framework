using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models
{
    [Table("CheckingAccounts")]
    public class CheckingAccount : Account
    {
        private double fee;

        public CheckingAccount()
        {
            this.Fee = 0;
        }

        public double Fee
        {
            get { return this.fee; }
            set { this.fee = value; }
        }

        public void DeductFee()
        {
            this.fee -= 2.5;
        }
    }
}
