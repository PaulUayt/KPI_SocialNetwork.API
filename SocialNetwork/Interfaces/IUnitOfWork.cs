using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Users> Users { get; }
        IRepository<FriendRequest> FriendRequest { get; }
        IRepository<MessList> MessList { get; }
        IRepository<Chat> Chat { get; }
        IRepository<Relationships> Relationships { get; }
        void Save();
        void Dispose();
    }
}
