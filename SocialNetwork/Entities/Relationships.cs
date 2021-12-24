using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.DAL.Entities
{
    public class Relationships
    {
        [Key]
        public int Id { get; set; }
        public int User1_Id { get; set; }

        //[ForeignKey("User1_Id")]
       // [NotMapped]
        public virtual Users Users1 { get; set; }

        public int User2_Id { get; set; }

       // [ForeignKey("User2_Id")]
        public virtual Users Users2 { get; set; }
    }
}
