namespace StudentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        public Resource()
        {
            this.Licenses = new HashSet<License>();
        }
        public int ResourceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string TypeOfResource { get; set; }

        public string URL { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}
