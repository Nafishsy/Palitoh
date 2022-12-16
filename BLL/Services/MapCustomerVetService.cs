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
    public class MapCustomerVetService
    {
        public static List<MapCustomerVetDTO> GetAllMapCustomerVets()
        {
            var data = DataAccessFactory.MapCustomerVetDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MapCustomerVet, MapCustomerVetDTO>());
            var mapper = new Mapper(config);
            var DTOMapCustomerVets = mapper.Map<List<MapCustomerVetDTO>>(data);
            return DTOMapCustomerVets;
        }
        public static MapCustomerVetDTO GetMapCustomerVet(int id)
        {
            var data = DataAccessFactory.MapCustomerVetDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MapCustomerVet, MapCustomerVetDTO>());
            var mapper = new Mapper(config);
            var DTOMapCustomerVet = mapper.Map<MapCustomerVetDTO>(data);
            return DTOMapCustomerVet;
        }

        public static List<MapCustomerVetDTO> GetAppointmentsOfVet(int id) //Specific Vet's Appoinments
        {
            var data = GetAllMapCustomerVets();
            var dt = data.FindAll(obj => obj.VetId == id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MapCustomerVet, MapCustomerVetDTO>());
            var mapper = new Mapper(config);
            var DTOMapCustomerVets = mapper.Map<List<MapCustomerVetDTO>>(dt);
            return DTOMapCustomerVets;
        }
        public static List<MapCustomerVetDTO> GetAppointmentsByTime(DateTime date) //Secific Date's 24 hour routine
        {

            var data = GetAllMapCustomerVets();
            var dt = (from d in data
                      where d.AppointmentDate <= date.Date
                      select d).ToList();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MapCustomerVet, MapCustomerVetDTO>());
            var mapper = new Mapper(config);
            var DTOMapCustomerVets = mapper.Map<List<MapCustomerVetDTO>>(dt);
            return DTOMapCustomerVets;

        }

        public static List<MapCustomerVetDTO> GetPastAppointmentsByTime() //Secific Date's 24 hour routine
        {

            var data = GetAllMapCustomerVets();
            var dt = (from d in data
                      where d.AppointmentDate != null
                      select d).ToList();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MapCustomerVet, MapCustomerVetDTO>());
            var mapper = new Mapper(config);
            var DTOMapCustomerVets = mapper.Map<List<MapCustomerVetDTO>>(dt);
            return DTOMapCustomerVets;

        }
        public static MapCustomerVetDTO AddMapCustomerVet(MapCustomerVetDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<MapCustomerVetDTO, MapCustomerVet>();
                cfg.CreateMap<MapCustomerVet, MapCustomerVetDTO>();
            });
            var mapper = new Mapper(config);
            var EFMapCustomerVet = mapper.Map<MapCustomerVet>(obj);
            var result = DataAccessFactory.MapCustomerVetDataAccess().Add(EFMapCustomerVet);

            return mapper.Map<MapCustomerVetDTO>(result);
        }
        public static MapCustomerVetDTO EditMapCustomerVet(MapCustomerVetDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<MapCustomerVetDTO, MapCustomerVet>();
                cfg.CreateMap<MapCustomerVet, MapCustomerVetDTO>();
            });
            var mapper = new Mapper(config);
            var EFMapCustomerVet = mapper.Map<MapCustomerVet>(obj);
            var result = DataAccessFactory.MapCustomerVetDataAccess().Update(EFMapCustomerVet);
            var DTOMapCustomerVet = mapper.Map<MapCustomerVetDTO>(obj);

            return DTOMapCustomerVet;
        }
        public static bool DeleteMapCustomerVet(MapCustomerVetDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<MapCustomerVetDTO, MapCustomerVet>();
                cfg.CreateMap<MapCustomerVet, MapCustomerVetDTO>();
            });
            var mapper = new Mapper(config);
            var EFMapCustomerVet = mapper.Map<MapCustomerVet>(obj);
            var result = DataAccessFactory.MapCustomerVetDataAccess().Delete(EFMapCustomerVet);
            return result;
        }
    }
}
