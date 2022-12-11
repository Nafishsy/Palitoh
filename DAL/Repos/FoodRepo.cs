using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class FoodRepo : Repo, IRepo<Food, int, Food>
    {
        public Food Add(Food obj)
        {
            db.Foods.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(Food obj)
        {
            var dbobj = Get(obj.Id);
            db.Foods.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Food> Get()
        {
            return db.Foods.ToList();
        }

        public Food Get(int id)
        {
            return db.Foods.Find(id);
        }

        public Food Update(Food obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
