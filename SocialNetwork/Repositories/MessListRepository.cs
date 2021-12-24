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
    class MessListRepository : IRepository<MessList>
    {
        private DataContext db;

        public MessListRepository(DataContext context)
        {
            this.db = context;
        }

        public void Create(MessList item)
        {
            db.MessList.Add(item);
        }

        public void Delete(int id)
        {
            MessList messList = db.MessList.Find(id);
            if (messList != null)
            {
                db.MessList.Remove(messList);
            }
        }

        public IEnumerable<MessList> Find(Expression<Func<MessList, bool>> predicate)
        {
            return db.MessList.Include(o => o.Users1).Include(o => o.Users2).Where(predicate).ToList();
        }

        public MessList Get(int id)
        {
            return db.MessList.Find(id);
        }

        public IEnumerable<MessList> GetAll()
        {
            return db.MessList.Include(o => o.Users1).Include(o => o.Users2);
        }

        public void Update(MessList item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
