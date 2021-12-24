using System;
using System.Collections.Generic;
using SocialNetwork.BLL.DTO;
using SocialNetwork.BLL.Interfaces;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Interfaces;
using SocialNetwork.BLL.Infrastructure;
using AutoMapper;

namespace SocialNetwork.BLL.Services
{
    public class FriendsService : IFriendsService
    {
        private IUnitOfWork Database;

        public FriendsService(IUnitOfWork uow)
        {
            Database = uow;
        }
        
        public ICollection<UsersDTO> FindByName(string name)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Users, UsersDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Users>, List<UsersDTO>>(Database.Users.Find(e => e.Name.Contains(name) || e.SurName.Contains(name) || e.Patronymic.Contains(name)));
        }

        public ICollection<FriendRequestDTO> GetAllFriendRequestsToUser(int? userId)
        {
            if (userId == null) throw new ValidationException("UserID is NULL", "");
            var mapper = new MapperConfiguration(config => config.CreateMap<FriendRequest, FriendRequestDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<FriendRequest>, List<FriendRequestDTO>>(Database.FriendRequest.Find(e => e.ToUser_Id == userId));
        }

        public ICollection<FriendRequestDTO> GetAllFriendRequestsFromUser(int? userId)
        {
            if (userId == null) throw new ValidationException("UserID is NULL", "");
            var mapper = new MapperConfiguration(config => config.CreateMap<FriendRequest, FriendRequestDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<FriendRequest>, List<FriendRequestDTO>>(Database.FriendRequest.Find(e => e.FromUser_Id == userId));
        }

        public ICollection<RelationshipsDTO> GetAllRelationships(int? userId)
        {
            if (userId == null) throw new ValidationException("UserID is NULL", "");
            var mapper = new MapperConfiguration(config => config.CreateMap<Relationships, RelationshipsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Relationships>, List<RelationshipsDTO>>(Database.Relationships.Find(e => e.User1_Id == userId.Value));
        }

        public string GetUserById(int userId)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Users, UsersDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Users>, List<UsersDTO>>(Database.Users.Find(e => e.Id == userId))[0].SurName + ' ' 
                + mapper.Map<IEnumerable<Users>, List<UsersDTO>>(Database.Users.Find(e => e.Id == userId))[0].Name;
        }

        public string GetRequestById(int userId)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<FriendRequest, FriendRequestDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Users>, List<UsersDTO>>(Database.Users.Find(e => e.Id == userId))[0].SurName + ' '
                + mapper.Map<IEnumerable<Users>, List<UsersDTO>>(Database.Users.Find(e => e.Id == userId))[0].Name;
        }

        public ICollection<UsersDTO> GetAllUsersInDB(int? userId)
        {
            if (userId == null) throw new ValidationException("UserID is NULL", ""); 
            var mapper = new MapperConfiguration(config => config.CreateMap<Users, UsersDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Users>, List<UsersDTO>>(Database.Users.Find(e => e.Id != userId.Value));
        }

        public void SendRequest(int? from_userId, int? to_userId)
        {
            if (to_userId == null || from_userId == null) throw new ValidationException("UserID is NULL", "");
            FriendRequest friendRequest = new FriendRequest {FromUser_Id = from_userId.Value, ToUser_Id = to_userId.Value };
            Database.FriendRequest.Create(friendRequest);
            Database.Save();
        }

        public ICollection<FriendRequestDTO> GetFriendRequestById(int friendReq_Id)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<FriendRequest, FriendRequestDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<FriendRequest>, List<FriendRequestDTO>>(Database.FriendRequest.Find(e => e.Id == friendReq_Id));
        }

        public void AddNewRelationships(int friendReq_id)
        {
            List<FriendRequestDTO> request = (List<FriendRequestDTO>)GetFriendRequestById(friendReq_id);
            Relationships relationships1_2 = new Relationships { User1_Id = request[0].FromUser_Id, User2_Id = request[0].ToUser_Id };
            Relationships relationships2_1 = new Relationships { User1_Id = request[0].ToUser_Id, User2_Id = request[0].FromUser_Id };
            
            Database.FriendRequest.Delete(request[0].Id);
            Database.Relationships.Create(relationships1_2);
            Database.Relationships.Create(relationships2_1);
            Database.Save();
        }

        public void DeleteFriendRequests(int friendreq_id)
        {
            Database.FriendRequest.Delete(friendreq_id);
            Database.Save();
        }

        public void AddNewChat(RelationshipsDTO relationships)
        {
            MessList messList = new MessList { User1_Id = relationships.User1_Id, User2_Id = relationships.User2_Id };
            Database.MessList.Create(messList);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
