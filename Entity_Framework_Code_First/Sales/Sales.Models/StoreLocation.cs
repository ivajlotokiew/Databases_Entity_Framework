namespace Sales.Models
{
    using System.Collections.Generic;

    public class StoreLocation
    {
        private ICollection<Sale> sale;

        public StoreLocation()
        {
            this.Sale = new HashSet<Sale>();
        }

        public int Id { get; set; }

        public string LocationName { get; set; }

        public virtual ICollection<Sale> Sale
        {
            get { return this.sale; }
            set { this.sale = value; }
        }
    }
}
