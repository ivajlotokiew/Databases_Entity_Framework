namespace BankSystem.Models
{
    public abstract class Account
    {
        private decimal balance;

        public Account()
        {
            this.Balance = 0;
        }

        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public void Deposit(decimal depostiSum)
        {
            this.balance += depostiSum;
        }

        public void Withdraw(decimal withdrawSum)
        {
            this.balance -= withdrawSum;
        }

        public virtual User User { get; set; }
    }
}
