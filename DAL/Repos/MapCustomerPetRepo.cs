using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MapCustomerPetRepo : Repo, IRepo<MapCustomerPet, int, MapCustomerPet>
    {
        public MapCustomerPet Add(MapCustomerPet obj)
        {
            db.MapCustomerPets.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(MapCustomerPet obj)
        {
            var dbobj = Get(obj.Id);
            db.MapCustomerPets.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<MapCustomerPet> Get()
        {
            return db.MapCustomerPets.ToList();
        }

        public MapCustomerPet Get(int id)
        {
            return db.MapCustomerPets.Find(id);
        }

        public MapCustomerPet Update(MapCustomerPet obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
