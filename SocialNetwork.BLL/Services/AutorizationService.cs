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
    public class AutorizationService : IAutorizationService
    {
        private IUnitOfWork Database;

        public AutorizationService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public UsersDTO LogIn(string email, string password)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Users, UsersDTO>()).CreateMapper();
            var users = mapper.Map<IEnumerable<Users>, List<UsersDTO>>(Database.Users.Find(ex => ex.Email.Equals(email)));

            //if (users.Count == 1) throw new ValidationException("User already exist", "");
            if (users.Count == 0) throw new ValidationException("User doesn't exist", "");
            if (users.Count > 1) throw new ValidationException("Colision in database", "");

            UsersDTO usersDTO = users[0];

            if (usersDTO.Password.Equals(password))
            {
                return usersDTO;
            }
            else
            {
                throw new ValidationException("Password don't match", "");
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
