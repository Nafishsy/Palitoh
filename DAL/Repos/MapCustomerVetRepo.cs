using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MapCustomerVetRepo : Repo, IRepo<MapCustomerVet, int, MapCustomerVet>
    {
        public MapCustomerVet Add(MapCustomerVet obj)
        {
            db.MapCustomerVets.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(MapCustomerVet obj)
        {
            var dbobj = Get(obj.Id);
            db.MapCustomerVets.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<MapCustomerVet> Get()
        {
            return db.MapCustomerVets.ToList();
        }

        public MapCustomerVet Get(int id)
        {
            return db.MapCustomerVets.Find(id);
        }

        public MapCustomerVet Update(MapCustomerVet obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
