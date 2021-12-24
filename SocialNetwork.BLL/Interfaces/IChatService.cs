using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BLL.DTO;

namespace SocialNetwork.BLL.Interfaces
{
    public interface IChatService
    {
        ICollection<ChatDTO> GetChatByMessListId(int? messListId);
        void SendMess(MessListDTO messListId, string text);
        string GetNameById(int userId);
        void Dispose();
    }
}
