using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.DAL.Entities
{
    public class FriendRequest
    {
        [Key]
        public int Id { get; set; }

        public int FromUser_Id { get; set; }

       // [ForeignKey("FromUser_Id")]
       // [NotMapped]
        public virtual Users FromUsers { get; set; }

        public int ToUser_Id { get; set; }

       // [ForeignKey("ToUser_Id")]
        public virtual Users ToUsers { get; set; }
    }
}
