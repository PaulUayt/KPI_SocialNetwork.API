using System.Collections.Generic;
using SocialNetwork.BLL.DTO;
using SocialNetwork.BLL.Interfaces;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Interfaces;
using SocialNetwork.BLL.Infrastructure;
using AutoMapper;

namespace SocialNetwork.BLL.Services
{
    public class MessListService : IMessListService
    {
        private IUnitOfWork Database;
        public MessListService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public ICollection<MessListDTO> GetAllMessLists(int userId)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<MessList, MessListDTO>()).CreateMapper();   
            return mapper.Map<IEnumerable<MessList>, List<MessListDTO>>(Database.MessList.Find(e => e.User1_Id == userId || e.User2_Id == userId));
        }

        public string GetUserById(int userId)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Users, UsersDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Users>, List<UsersDTO>>(Database.Users.Find(e => e.Id == userId))[0].SurName + ' '
                + mapper.Map<IEnumerable<Users>, List<UsersDTO>>(Database.Users.Find(e => e.Id == userId))[0].Name;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
