namespace UserDB.Models
{
    using System.Collections.Generic;

    public class Town
    {
        private ICollection<User> users;

        public Town()
        {
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
