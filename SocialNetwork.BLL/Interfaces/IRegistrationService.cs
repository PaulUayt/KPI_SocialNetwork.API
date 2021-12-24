using System;
using System.Collections.Generic;
using SocialNetwork.BLL.DTO;

namespace SocialNetwork.BLL.Interfaces
{
    public interface IRegistrationService
    {
        void RegistrateUser(UsersDTO usersDTO);
        void Dispose();
    }
}
