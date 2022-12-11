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
    public class AdminService
    {

        public static List<AdminDTO> GetAllAdmins()
        {
            var data = DataAccessFactory.AdminDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Admin, AdminDTO>());
            var mapper = new Mapper(config);
            var DTOAdmins = mapper.Map<List<AdminDTO>>(data);
            return DTOAdmins;
        }
        public static AdminDTO GetAdmin(int id)
        {
            var data = DataAccessFactory.AdminDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Admin, AdminDTO>());
            var mapper = new Mapper(config);
            var DTOAdmin = mapper.Map<AdminDTO>(data);
            return DTOAdmin;
        }
        public static AdminDTO AddAdmin(AdminDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AdminDTO, Admin>();
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var EFAdmin = mapper.Map<Admin>(obj);
            var result = DataAccessFactory.AdminDataAccess().Add(EFAdmin);

            return mapper.Map<AdminDTO>(result);
        }
        public static AdminDTO EditAdmin(AdminDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AdminDTO, Admin>();
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var EFAdmin = mapper.Map<Admin>(obj);
            var result = DataAccessFactory.AdminDataAccess().Update(EFAdmin);
            var DTOAdmin = mapper.Map<AdminDTO>(obj);

            return DTOAdmin;
        }
        public static bool DeleteAdmin(AdminDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AdminDTO, Admin>();
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var EFAdmin = mapper.Map<Admin>(obj);
            var result = DataAccessFactory.AdminDataAccess().Delete(EFAdmin);
            return result;
        }
    }
}
