using System;

namespace SocialNetwork.BLL.DTO
{
    public class UsersDTO
    {
        public int Id { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string BirthdayCity { get; set; }
        public string Birthday { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
