namespace Sales.Models
{
    using System.Collections.Generic;

    public class Product
    {
        private ICollection<Sale> sale;

        public Product()
        {
            this.Sale = new HashSet<Sale>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Sale> Sale
        {
            get { return this.sale; }
            set { this.sale = value; }
        }
    }
}
