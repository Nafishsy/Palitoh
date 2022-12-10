using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class VetRepo : Repo, IRepo<Vet, int, Vet>
    {
        public Vet Add(Vet obj)
        {
            db.Vets.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(Vet obj)
        {
            var dbobj = Get(obj.Id);
            db.Vets.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Vet> Get()
        {
            return db.Vets.ToList();
        }

        public Vet Get(int id)
        {
            return db.Vets.Find(id);
        }

        public Vet Update(Vet obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
