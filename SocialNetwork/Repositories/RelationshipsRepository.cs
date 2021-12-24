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
    class RelationshipsRepository : IRepository<Relationships>
    {
        private DataContext db;

        public RelationshipsRepository(DataContext context)
        {
            this.db = context;
        }

        public void Create(Relationships item)
        {
            db.Relationships.Add(item);
        }

        public void Delete(int id)
        {
            Relationships relationships = db.Relationships.Find(id);
            if (relationships != null)
            {
                db.Relationships.Remove(relationships);
            }
        }

        public IEnumerable<Relationships> Find(Expression<Func<Relationships, bool>> predicate)
        {
            return db.Relationships.Include(o => o.Users1).Include(o => o.Users2).Where(predicate).ToList();
        }

        public Relationships Get(int id)
        {
            return db.Relationships.Find(id);
        }

        public IEnumerable<Relationships> GetAll()
        {
            return db.Relationships.Include(o => o.Users1).Include(o => o.Users2);
        }

        public void Update(Relationships item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
