namespace BankSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Accounts = new HashSet<Account>();
            this.Login = false;
        }

        public bool Login { get; set; }

        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]{1}[a-zA-Z\d]{2,}$", ErrorMessage =
            "Incorrect username")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)[A-Za-z\d]{7,}$", ErrorMessage =
            "Incorrect password")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^([a-z, A-Z, 0-9]{1})([a-z, A-Z, 0-9, _\.-]*)([a-z, A-Z, 0-9]{1})@([a-z, A-Z, 0-9]+)\.([a-z, A-Z, 0-9, \.]+)([a-z, A-Z, 0-9]{1})$",
            ErrorMessage = "Incorrect email")]
        public string Email { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
