namespace Sales.Models
{
    using System.Collections.Generic;

    public class Customer
    {
        private ICollection<Sale> sale;

        public Customer()
        {
            this.Sale = new HashSet<Sale>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string CreditCardNumber { get; set; }

        public virtual ICollection<Sale> Sale
        {
            get { return this.sale; }
            set { this.sale = value; }
        }
    }
}
