using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MapCustomerFoodRepo : Repo, IRepo<MapCustomerFood, int, MapCustomerFood>
    {
        public MapCustomerFood Add(MapCustomerFood obj)
        {
            db.MapCustomerFoods.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(MapCustomerFood obj)
        {
            var dbobj = Get(obj.Id);
            db.MapCustomerFoods.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<MapCustomerFood> Get()
        {
            return db.MapCustomerFoods.ToList();
        }

        public MapCustomerFood Get(int id)
        {
            return db.MapCustomerFoods.Find(id);
        }

        public MapCustomerFood Update(MapCustomerFood obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
