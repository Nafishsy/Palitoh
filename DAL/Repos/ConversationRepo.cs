using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ConversationRepo : Repo, IRepo<Conversation, int, Conversation>
    {
        public Conversation Add(Conversation obj)
        {
            db.Conversations.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(Conversation obj)
        {
            var dbobj = Get(obj.Id);
            db.Conversations.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Conversation> Get()
        {
            return db.Conversations.ToList();
        }

        public Conversation Get(int id)
        {
            return db.Conversations.Find(id);
        }

        public Conversation Update(Conversation obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
