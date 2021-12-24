using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.DAL.Entities
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }

        public int messList_Id { get; set; }

        [ForeignKey("messList_Id")]
        public MessList MessList { get; set; }

        public int FromUser_Id { get; set; }

        //[ForeignKey("FromUser_Id")]
        public virtual Users FromUsers { get; set; }

        public int ToUser_Id { get; set; }

        //[ForeignKey("ToUser_Id")]
        public virtual Users ToUsers { get; set; }

        [MaxLength(200)]
        [DataType(DataType.Text, ErrorMessage = "Text is invalid")]
        public string Text { get; set; }
    }
}
