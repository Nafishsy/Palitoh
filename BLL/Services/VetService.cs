using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class VetService
    {
        public static List<VetDTO> GetAllVets()
        {
            var data = DataAccessFactory.VetDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Vet, VetDTO>());
            var mapper = new Mapper(config);
            var DTOVets = mapper.Map<List<VetDTO>>(data);
            return DTOVets;
        }

        public static object GetAllVetsInfo()
        {
            var data = GetAllVets();
            var accounts = AccountService.GetAllAccounts();
            var List = (from dt in data
                        join ac in accounts on dt.Id equals ac.Id
                        orderby ac.Name
                        select new { ac.Name,dt.Id,dt.Location,dt.Designation,dt.AppointmentFees}).ToList();
            return List;
        }
        public static VetDTO GetVet(int id)
        {
            var data = DataAccessFactory.VetDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Vet, VetDTO>());
            var mapper = new Mapper(config);
            var DTOVet = mapper.Map<VetDTO>(data);
            return DTOVet;
        }
        public static VetDTO AddVet(VetDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<VetDTO, Vet>();
                cfg.CreateMap<Vet, VetDTO>();
            });
            var mapper = new Mapper(config);
            var EFVet = mapper.Map<Vet>(obj);
            var result = DataAccessFactory.VetDataAccess().Add(EFVet);

            return mapper.Map<VetDTO>(result);
        }
        public static VetDTO EditVet(VetDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<VetDTO, Vet>();
                cfg.CreateMap<Vet, VetDTO>();
            });
            var mapper = new Mapper(config);
            var EFVet = mapper.Map<Vet>(obj);
            var result = DataAccessFactory.VetDataAccess().Update(EFVet);
            var DTOVet = mapper.Map<VetDTO>(obj);

            return DTOVet;
        }
        public static bool DeleteVet(VetDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<VetDTO, Vet>();
                cfg.CreateMap<Vet, VetDTO>();
            });
            var mapper = new Mapper(config);
            var EFVet = mapper.Map<Vet>(obj);
            var result = DataAccessFactory.VetDataAccess().Delete(EFVet);
            return result;
        }
        public static VetsCustomerDTO GetAllAppoinments(int id)
        {
            //Aikhane Akta Vet er jonno or shob Customer/Paitent Der info Ashbe
            var data = DataAccessFactory.VetDataAccess().Get(id);

            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Vet, VetsCustomerDTO>();
                c.CreateMap<Customer, CustomerDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<VetsCustomerDTO>(data);
        }
        public static object SearchVet(string name)
        //object return korsi karon ami annonymous er modhe ak sathe duita data rakhsi, akt data er jonno notun DTO na banay
        //name dile name ashbe vetDTO dile customer er object er shob properties use korte parar kotha
        {
            var userName = (from dt in AccountService.GetAllAccounts()
                            where dt.Name.ToLower().StartsWith(name.ToLower()) && dt.Type == "Vet"
                            select dt).SingleOrDefault();

            if (userName == null)
                return null;
            else
            {
                var userInfo = (from dt in GetAllVets()
                                where dt.Id == userName.Id
                                select dt).SingleOrDefault();

                var obj = new { name = userName.Name, VetDTO = userInfo };
                return obj;
            }

        }

    }
}
