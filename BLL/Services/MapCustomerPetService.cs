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
    public class MapCustomerPetService
    {
        public static List<MapCustomerPetDTO> GetAllMapCustomerPets()
        {
            var data = DataAccessFactory.MapCustomerPetDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MapCustomerPet, MapCustomerPetDTO>());
            var mapper = new Mapper(config);
            var DTOMapCustomerPets = mapper.Map<List<MapCustomerPetDTO>>(data);
            return DTOMapCustomerPets;
        }
        public static MapCustomerPetDTO GetMapCustomerPet(int id)
        {
            var data = DataAccessFactory.MapCustomerPetDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MapCustomerPet, MapCustomerPetDTO>());
            var mapper = new Mapper(config);
            var DTOMapCustomerPet = mapper.Map<MapCustomerPetDTO>(data);
            return DTOMapCustomerPet;
        }
        public static MapCustomerPetDTO AddMapCustomerPet(MapCustomerPetDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<MapCustomerPetDTO, MapCustomerPet>();
                cfg.CreateMap<MapCustomerPet, MapCustomerPetDTO>();
            });
            var mapper = new Mapper(config);
            var EFMapCustomerPet = mapper.Map<MapCustomerPet>(obj);
            var result = DataAccessFactory.MapCustomerPetDataAccess().Add(EFMapCustomerPet);

            return mapper.Map<MapCustomerPetDTO>(result);
        }
        public static MapCustomerPetDTO EditMapCustomerPet(MapCustomerPetDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<MapCustomerPetDTO, MapCustomerPet>();
                cfg.CreateMap<MapCustomerPet, MapCustomerPetDTO>();
            });
            var mapper = new Mapper(config);
            var EFMapCustomerPet = mapper.Map<MapCustomerPet>(obj);
            var result = DataAccessFactory.MapCustomerPetDataAccess().Update(EFMapCustomerPet);
            var DTOMapCustomerPet = mapper.Map<MapCustomerPetDTO>(obj);

            return DTOMapCustomerPet;
        }
        public static bool DeleteMapCustomerPet(MapCustomerPetDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<MapCustomerPetDTO, MapCustomerPet>();
                cfg.CreateMap<MapCustomerPet, MapCustomerPetDTO>();
            });
            var mapper = new Mapper(config);
            var EFMapCustomerPet = mapper.Map<MapCustomerPet>(obj);
            var result = DataAccessFactory.MapCustomerPetDataAccess().Delete(EFMapCustomerPet);
            return result;
        }

        public static bool Adopt(int id,int c_id,DateTime date) //adopt e tip dibe customer er id session/cookie diye c_id e boshbe
                                                                //id hoche pet id aita list er niche adopt button er hyperlink e rakhlam
                                                                // er por date fix korlam
        {
            var data = PetService.GetPet(id);
            if ( data==null || data.Status!= "Available")
            {
                //jodi pet table ei na thake taile back
                return false;
            }
            else
            {
                var customerPet = new MapCustomerPetDTO { PetId = id, CustomerId = c_id, EmployeeId = null, AdoptionRequestTime = date };

                if (AddMapCustomerPet(customerPet) != null)
                {
                    return true;
                }

            }
            

            return false;
        }
    }
}
