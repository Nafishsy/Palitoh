using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AccountRepo : Repo, IRepo<Account, int, Account>,IAuth
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

        public Token Authenticate(Account user)
        {
            var u = db.Accounts.FirstOrDefault(e=>e.UserName.Equals(user.UserName) && e.Password.Equals(user.Password));
            Token t = null;
            if (u != null)
            {
                string token = Guid.NewGuid().ToString();
                t = new Token();
                t.AccountId = u.Id;
                t.AccessToken = token;
                t.CreatedAt = DateTime.Now;
                db.Tokens.Add(t);
                db.SaveChanges();
            }
            return t;
        }

        public bool isAuthenticated(string token)
        {
            var rs = db.Tokens.Any(e=>e.AccessToken.Equals(token) && e.ExpiredAt == null);
            return rs;
        }

        public bool Logout(string token)
        {
            //Age implemented asilo
            var data = db.Tokens.FirstOrDefault(e => e.AccessToken.Equals(token));
            db.Tokens.Remove(data);
            return db.SaveChanges() > 0;
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
