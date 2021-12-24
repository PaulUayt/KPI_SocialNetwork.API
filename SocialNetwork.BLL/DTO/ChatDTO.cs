namespace SocialNetwork.BLL.DTO
{
    public class ChatDTO
    {
        public int Id { get; set; }
        public int messList_Id { get; set; }
        public int FromUser_Id { get; set; }
        public int ToUser_Id { get; set; }
        public string Text { get; set; }
    }
}
