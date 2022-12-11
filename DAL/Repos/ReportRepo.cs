using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ReportRepo : Repo, IRepo<Report, int, Report>
    {
        public Report Add(Report obj)
        {
            db.Reports.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(Report obj)
        {
            var dbobj = Get(obj.Id);
            db.Reports.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Report> Get()
        {
            return db.Reports.ToList();
        }

        public Report Get(int id)
        {
            return db.Reports.Find(id);
        }

        public Report Update(Report obj)
        {
            var dbobj = Get(obj.Id);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
