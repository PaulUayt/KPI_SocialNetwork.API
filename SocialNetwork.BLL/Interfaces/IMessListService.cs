using System;
using System.Collections.Generic;
using SocialNetwork.BLL.DTO;

namespace SocialNetwork.BLL.Interfaces
{
    public interface IMessListService
    {
        ICollection<MessListDTO> GetAllMessLists(int userId);
        string GetUserById(int userId);
        void Dispose();
    }
}
