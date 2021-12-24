using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.DAL.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string SurName { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Patronymic { get; set; }

        [Required]
        [MaxLength(32)]
        public string BirthdayCity { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        [DataType(DataType.Date, ErrorMessage = "Birthday is invalid")]
        public string Birthday { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number is invalid")]
        public string Mobile { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public ICollection<FriendRequest> FriendRequestFrom { get; set; }
        public ICollection<FriendRequest> FriendRequestTo { get; set; }
        public ICollection<MessList> MessList1 { get; set; }
        public ICollection<MessList> MessList2 { get; set; }
        public ICollection<Relationships> Relationships1 { get; set; }
        public ICollection<Relationships> Relationships2 { get; set; }
        public ICollection<Chat> ChatTo { get; set; }
        public ICollection<Chat> ChatFrom { get; set; }
    }
}
