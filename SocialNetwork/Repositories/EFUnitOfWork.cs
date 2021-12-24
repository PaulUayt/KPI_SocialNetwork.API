using System;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Interfaces;
using SocialNetwork.DAL.EF;

namespace SocialNetwork.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposed = false;
        private DataContext db;
        private UsersRepository usersRepository;
        private MessListRepository messListRepository;
        private FriendRequestRepository friendRequestRepository;
        private RelationshipsRepository relationshipsRepository;
        private ChatRepository chatRepository;

        public EFUnitOfWork(DataContext context)
        {
            db = context;
        }

        public IRepository<Users> Users
        {
            get
            {
                if (usersRepository == null)
                {
                    usersRepository = new UsersRepository(db);
                }
                return usersRepository;
            }
        }

        public IRepository<FriendRequest> FriendRequest
        {
            get
            {
                if (friendRequestRepository == null)
                {
                    friendRequestRepository = new FriendRequestRepository(db);
                }
                return friendRequestRepository;
            }
        }

        public IRepository<Relationships> Relationships
        {
            get
            {
                if (relationshipsRepository == null)
                {
                    relationshipsRepository = new RelationshipsRepository(db);
                }
                return relationshipsRepository;
            }
        }
        public IRepository<MessList> MessList 
        {
            get
            {
                if (messListRepository == null)
                {
                    messListRepository = new MessListRepository(db);
                }
                return messListRepository;
            }
        }

        public IRepository<Chat> Chat 
        {
            get
            {
                if (chatRepository == null)
                {
                    chatRepository = new ChatRepository(db);
                }
                return chatRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
