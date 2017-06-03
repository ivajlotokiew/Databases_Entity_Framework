namespace UserDB.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*(_|[^\w])).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^([a-z, A-Z, 0-9]{1})([a-z, A-Z, 0-9, _\.-]*)([a-z, A-Z, 0-9]{1})@([a-z, A-Z, 0-9]+)\.([a-z, A-Z, 0-9, \.]+)([a-z, A-Z, 0-9]{1})$")]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public byte[] Image { get; set; }

        public DateTime? RegisteredOn { get; set; }

        public DateTime? LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int? Age { get; set; }

        public bool IsDeleted { get; set; }

        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
