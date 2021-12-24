using System;
using System.Collections.Generic;
using SocialNetwork.BLL.DTO;

namespace SocialNetwork.BLL.Interfaces
{
    public interface IAutorizationService
    {
        UsersDTO LogIn(string email, string password);
        void Dispose();
    }
}
