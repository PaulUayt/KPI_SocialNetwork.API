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
    class ChatRepository : IRepository<Chat>
    {
        private DataContext db;

        public ChatRepository(DataContext context)
        {
            this.db = context;
        }

        public void Create(Chat item)
        {
            db.Chat.Add(item);
        }

        public void Delete(int id)
        {
            Chat chat = db.Chat.Find(id);
            if (chat != null)
            {
                db.Chat.Remove(chat);
            }
        }

        public IEnumerable<Chat> Find(Expression<Func<Chat, bool>> predicate)
        {
            return db.Chat./*Include(o => o.FromUsers).Include(o => o.ToUsers).*/Include(o => o.MessList).Where(predicate).ToList();
        }

        public Chat Get(int id)
        {
            return db.Chat.Find(id);
        }

        public IEnumerable<Chat> GetAll()
        {
            return db.Chat.Include(o => o.FromUsers).Include(o => o.ToUsers).Include(o => o.MessList);
        }

        public void Update(Chat item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
