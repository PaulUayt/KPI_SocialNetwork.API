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
    public class ChatService : IChatService
    {
        private IUnitOfWork Database;

        public ChatService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public ICollection<ChatDTO> GetChatByMessListId(int? messListId)
        {
            if (messListId == null) throw new ValidationException("MessListId is NULL","");
            var mapper = new MapperConfiguration(config => config.CreateMap<Chat, ChatDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Chat>, List<ChatDTO>>(Database.Chat.Find(e => e.messList_Id == messListId));
        }

        public string GetNameById(int userId)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Users, UsersDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Users>, List<UsersDTO>>(Database.Users.Find(e => e.Id == userId))[0].Name;
        }

        public void SendMess(MessListDTO messListId, string text)
        {
            Chat chat = new Chat { 
                messList_Id = messListId.Id, 
                FromUser_Id = messListId.User1_Id, 
                ToUser_Id = messListId.User2_Id, 
                Text = text 
            };
            Database.Chat.Create(chat);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
