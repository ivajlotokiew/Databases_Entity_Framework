namespace UserDB.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        private ICollection<Town> towns;

        public Country()
        {
            this.Towns = new HashSet<Town>();
        }

        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(80)]
        public string Name { get; set; }

        public ICollection<Town> Towns
        {
            get { return this.towns; }
            set { this.towns = value; }
        }
    }
}
