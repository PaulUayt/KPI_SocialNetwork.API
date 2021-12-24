using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BLL.DTO;

namespace SocialNetwork.BLL.Interfaces
{
    public interface IFriendsService
    {
        ICollection<RelationshipsDTO> GetAllRelationships(int? userId);
        ICollection<FriendRequestDTO> GetAllFriendRequestsToUser(int? userId);
        ICollection<FriendRequestDTO> GetAllFriendRequestsFromUser(int? userId);
        ICollection<UsersDTO> GetAllUsersInDB(int? userId);
        ICollection<UsersDTO> FindByName(string name);
        ICollection<FriendRequestDTO> GetFriendRequestById(int friendReq_Id);
        string GetUserById(int userId);
        void SendRequest(int? from_userId, int? to_userId);
        void AddNewChat(RelationshipsDTO relationships);
        void AddNewRelationships(int friendReq_id);
        //void DeleteFriendRequests(FriendRequestDTO friendRequest);
        void DeleteFriendRequests(int friendreq_id);
        //void DeleteFriendRequests(FriendRequestDTO friendRequest);
        void Dispose();
    }
}
