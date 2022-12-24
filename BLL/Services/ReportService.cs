using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReportService
    {
        public static List<ReportDTO> GetAllReports()
        {
            var data = DataAccessFactory.ReportDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Report, ReportDTO>());
            var mapper = new Mapper(config);
            var DTOReports = mapper.Map<List<ReportDTO>>(data);
            return DTOReports;
        }
        public static ReportDTO GetReport(int id)
        {
            var data = DataAccessFactory.ReportDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Report, ReportDTO>());
            var mapper = new Mapper(config);
            var DTOReport = mapper.Map<ReportDTO>(data);
            return DTOReport;
        }
        public static ReportDTO AddReport(ReportDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ReportDTO, Report>();
                cfg.CreateMap<Report, ReportDTO>();
            });
            var mapper = new Mapper(config);
            var EFReport = mapper.Map<Report>(obj);
            var result = DataAccessFactory.ReportDataAccess().Add(EFReport);

            return mapper.Map<ReportDTO>(result);
        }
        public static ReportDTO EditReport(ReportDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ReportDTO, Report>();
                cfg.CreateMap<Report, ReportDTO>();
            });
            var mapper = new Mapper(config);
            var EFReport = mapper.Map<Report>(obj);
            var result = DataAccessFactory.ReportDataAccess().Update(EFReport);
            var DTOReport = mapper.Map<ReportDTO>(obj);

            return DTOReport;
        }
        public static bool DeleteReport(ReportDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ReportDTO, Report>();
                cfg.CreateMap<Report, ReportDTO>();
            });
            var mapper = new Mapper(config);
            var EFReport = mapper.Map<Report>(obj);
            var result = DataAccessFactory.ReportDataAccess().Delete(EFReport);
            return result;
        }

        public static object AllReports()
        {
            var data = GetAllReports();
            var dt = (from d in data
                      join ac in AccountService.GetAllAccounts() on d.Id equals ac.Id
                      select new { ac.Name, d }).ToList();
            return dt;
        }

        public static object SearchReports(string name)
        {
            var data = GetAllReports();
            var dt = (from d in data
                      join ac in AccountService.GetAllAccounts() on d.Id equals ac.Id
                      where ac.Name.ToLower().StartsWith(name.ToLower())
                      select new { ac.Name, d }).ToList();
            return dt;

        }
    }
}
