using System.Collections.Generic;
using SocialNetwork.BLL.DTO;
using SocialNetwork.BLL.Interfaces;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Interfaces;
using SocialNetwork.BLL.Infrastructure;
using AutoMapper;

namespace SocialNetwork.BLL.Services
{
    public class MainPageService : IMainPageService
    {
        private IUnitOfWork Database;

        public MainPageService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public int GetFriendsCount(int? userId)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Relationships, RelationshipsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Relationships>, List<RelationshipsDTO>>(Database.Relationships.Find(e => e.User1_Id == userId)).Count;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public UsersDTO GetUserById(int userId)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Users, UsersDTO>()).CreateMapper();
            var user = mapper.Map<IEnumerable<Users>, List<UsersDTO>>(Database.Users.Find(e => e.Id == userId));
            if (user.Count == 0) throw new ValidationException("User with this ID is miss", "");
            UsersDTO _user = new UsersDTO
            {
                Id = user[0].Id,
                SurName = user[0].SurName,
                Name = user[0].Name,
                Patronymic = user[0].Patronymic,
                BirthdayCity = user[0].BirthdayCity,
                Birthday = user[0].Birthday,
                Email = user[0].Email,
                Mobile = user[0].Mobile,
                Password = "",
                RegistrationDate = user[0].RegistrationDate
            };
            return _user;
        }
    }
}
