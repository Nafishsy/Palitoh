using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ShopRepo : Repo, IRepo<Shop, int, Shop>
    {
        public Shop Add(Shop obj)
        {
            db.Shops.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(Shop obj)
        {
            var dbobj = Get(obj.Id);
            db.Shops.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Shop> Get()
        {
            return db.Shops.ToList();
        }

        public Shop Get(int id)
        {
            return db.Shops.Find(id);
        }

        public Shop Update(Shop obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
