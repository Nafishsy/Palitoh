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
        public static MapCustomerVetDTO GetMapCustomerVet(int id) // For VET , All paintents
        {
            var data = DataAccessFactory.MapCustomerVetDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MapCustomerVet, MapCustomerVetDTO>());
            var mapper = new Mapper(config);
            var DTOMapCustomerVet = mapper.Map<MapCustomerVetDTO>(data);
            return DTOMapCustomerVet;
        }

        public static object GetAppointmentsOfVet(int id) //Specific Vet's Appoinments
        {
            var data = (from dt in GetAllMapCustomerVets()
                        join ac in AccountService.GetAllAccounts() on dt.CustomerId equals ac.Id
                        orderby ac.Name
                        where dt.VetId == id
                        select new { ac.Name, dt.AppointmentDate, Customer_id = ac.Id, dt.Id }).ToList();
            return data;
        }
        public static object GetAppointmentsOfCus(int id) //Specific Vet's Appoinments
        {
            var data = (from dt in GetAllMapCustomerVets()
                        join ac in AccountService.GetAllAccounts() on dt.VetId equals ac.Id
                        orderby ac.Name
                        where dt.CustomerId == id
                        select new { ac.Name, dt.AppointmentDate, dt.Id ,VetId = ac.Id}).ToList();
            return data;
        }

        public static object SearchVetsPatient(string name,int id) //Specific Vet's Appoinments er upor User name diya Search
        {
            var data = (from dt in GetAllMapCustomerVets()
                        join ac in AccountService.GetAllAccounts() on dt.CustomerId equals ac.Id
                        orderby ac.Name
                        where dt.VetId == id && ac.Name.ToLower().StartsWith(name.ToLower())
                        select new { ac.Name, dt.AppointmentDate, Customer_id = ac.Id, dt.Id }).ToList();
            return data;
        }

        public static object SearchVetsPatientByDTD(SearchFormDTO srch) //Specific Vet's Appoinments er upor User name diya Date time to Date time
        {
            if(srch.EndDate == null)
            {
                srch.EndDate = DateTime.Now;
            }
            var data = (from dt in GetAllMapCustomerVets()
                        join ac in AccountService.GetAllAccounts() on dt.CustomerId equals ac.Id
                        orderby ac.Name
                        where dt.VetId == srch.Id && dt.AppointmentDate.Date >= srch.StartDate && (dt.AppointmentDate.Date <= srch.EndDate || srch.EndDate==null)
                        select new { ac.Name, dt.AppointmentDate, Customer_id =ac.Id ,dt.Id}).ToList();
            return data;
        }
        public static object GetAppointmentsHistoryUser(DateTime date,int id) //Secific Date's er ager appointments for USER
        {

            var data = GetAllMapCustomerVets();
            var dd = (from dt in data
                      join ac in AccountService.GetAllAccounts() on dt.CustomerId equals ac.Id
                      orderby ac.Name
                      where dt.CustomerId == id && dt.AppointmentDate.Date <= date.Date
                      select new { ac.Name, dt.AppointmentDate ,ac.Id}).ToList();
            return dd;

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

        public static bool SetAppointment (MapCustomerVetDTO appoint)
        {
            if(appoint.AppointmentDate.Date <= System.DateTime.Now.Date)
            {
                appoint.AppointmentDate = System.DateTime.Now.Date.AddDays(2);
            }

            if(AddMapCustomerVet(appoint)!=null)
            {
                return true;
            }
            return false;
        }

        public static string GetName(int id) //Admin Data dekhbe Consulation er
        {
            var acc = AccountService.GetAllAccounts();

            foreach (var item in acc)
            {
                if(item.Id == id)
                {
                    return item.Name;
                }
            }
            return null;
        }

        public static string GetFoodName(int id) //Admin Data dekhbe Consulation er
        {
            var acc = FoodService.GetAllFoods();

            foreach (var item in acc)
            {
                if (item.Id == id)
                {
                    return item.Name;
                }
            }
            return null;
        }
        public static List<object> ConsultationData() //Admin Data dekhbe Consulation er
        {

            var data = GetAllMapCustomerVets();
            var acc = AccountService.GetAllAccounts();

            List<object> list = new List<object>();

            foreach (var item in data)
            {
                var VetName = GetName(item.VetId);
                var CusName = GetName(item.CustomerId);

                list.Add(new { VetName, CusName , item.AppointmentDate});
             
            }

            return list;

        }

        public static List<object> ShopData() //Admin Data dekhbe Shop er
        {

            var data = MapCustomerFoodService.GetAllMapCustomerFoods();
            var acc = AccountService.GetAllAccounts();

            List<object> list = new List<object>();

            foreach (var item in data)
            {
                var FoodName = GetFoodName(item.FoodId);
                var CusName = GetName(item.CustomerId);

                list.Add(new { FoodName, CusName, item.RequestItemTime });

            }

            return list;

        }


    }
}
