using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AccountRepo : Repo, IRepo<Account, int, Account>
    {
        public Account Add(Account obj)
        {
            db.Accounts.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(Account obj)
        {
            var dbobj = Get(obj.Id);
            db.Accounts.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Account> Get()
        {
            return db.Accounts.ToList();
        }

        public Account Get(int id)
        {
            return db.Accounts.Find(id);
        }

        public Account Update(Account obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
