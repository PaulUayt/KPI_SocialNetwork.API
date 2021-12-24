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
    public class RegistrationService : IRegistrationService
    {
        private IUnitOfWork Database;

        public RegistrationService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void RegistrateUser(UsersDTO usersDTO)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Users, UsersDTO>()).CreateMapper();
            var users = mapper.Map<IEnumerable<Users>, List<UsersDTO>>(Database.Users.Find(ex => ex.Email.Equals(usersDTO.Email)));

            if (users.Count != 0) throw new ValidationException("User already exist", "");

            Users _users = new Users
            {
                Id = usersDTO.Id,
                SurName = usersDTO.SurName,
                Name = usersDTO.Name,
                Patronymic = usersDTO.Patronymic,
                BirthdayCity = usersDTO.BirthdayCity,
                Birthday = usersDTO.Birthday,
                Password = usersDTO.Password,
                Email = usersDTO.Email,
                Mobile = usersDTO.Mobile,
                RegistrationDate = DateTime.Now
            };

            Database.Users.Create(_users);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
