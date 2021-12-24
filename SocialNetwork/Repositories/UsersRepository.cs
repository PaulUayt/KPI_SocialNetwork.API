using System;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.DAL.Interfaces;
using SocialNetwork.DAL.EF;
using SocialNetwork.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SocialNetwork.DAL.Repositories
{
    class UsersRepository : IRepository<Users>
    {
        private DataContext db;

        public UsersRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<Users> GetAll()
        {
            return db.Users;
        }

        public Users Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<Users> Find(Expression<Func<Users, bool>> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public void Create(Users item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            Users author = db.Users.Find(id);
            if (author != null)
            {
                db.Users.Remove(author);
            }
        }

        public void Update(Users item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
