using System;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.DAL.Interfaces;
using SocialNetwork.DAL.EF;
using SocialNetwork.DAL.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.DAL.Repositories
{
    class FriendRequestRepository : IRepository<FriendRequest>
    {
        private DataContext db;

        public FriendRequestRepository(DataContext context)
        {
            this.db = context;
        }

        public void Create(FriendRequest item)
        {
            db.FriendRequest.Add(item);
        }

        public void Delete(int id)
        {
            FriendRequest friendRequest = db.FriendRequest.Find(id);
            if (friendRequest != null)
            {
                db.FriendRequest.Remove(friendRequest);
            }
        }

        public IEnumerable<FriendRequest> Find(Expression<Func<FriendRequest, bool>> predicate)
        {
            return db.FriendRequest.Include(o => o.FromUsers).Include(o => o.ToUsers).Where(predicate).ToList();
        }

        public FriendRequest Get(int id)
        {
            return db.FriendRequest.Find(id);
        }

        public IEnumerable<FriendRequest> GetAll()
        {
            return db.FriendRequest.Include(o => o.FromUsers).Include(o => o.ToUsers);
        }

        public void Update(FriendRequest item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
