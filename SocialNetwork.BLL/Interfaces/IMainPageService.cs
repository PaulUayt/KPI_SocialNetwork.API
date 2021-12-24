using SocialNetwork.BLL.DTO;

namespace SocialNetwork.BLL.Interfaces
{
    public interface IMainPageService
    {
        int GetFriendsCount(int? userId);
        UsersDTO GetUserById(int userId);
        void Dispose();
    }
}
