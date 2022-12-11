using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PetRepo : Repo, IRepo<Pet, int, Pet>
    {
        public Pet Add(Pet obj)
        {
            db.Pets.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(Pet obj)
        {
            var dbobj = Get(obj.Id);
            db.Pets.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Pet> Get()
        {
            return db.Pets.ToList();
        }

        public Pet Get(int id)
        {
            return db.Pets.Find(id);
        }

        public Pet Update(Pet obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
