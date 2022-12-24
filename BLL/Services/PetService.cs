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
    public class PetService
    {
        public static List<PetDTO> GetAllPets()
        {
            var data = DataAccessFactory.PetDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Pet, PetDTO>());
            var mapper = new Mapper(config);
            var DTOPets = mapper.Map<List<PetDTO>>(data);
            return DTOPets;
        }

        public static List<PetDTO> GetAvailablePets()
        {
            var all = GetAllPets();
            var available = (from d in all
                             where d.Status == "Available"
                             select d).ToList();
            return available;
        }
        public static PetDTO GetPet(int id)
        {
            var data = DataAccessFactory.PetDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Pet, PetDTO>());
            var mapper = new Mapper(config);
            var DTOPet = mapper.Map<PetDTO>(data);
            return DTOPet;
        }
        public static PetDTO AddPet(PetDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PetDTO, Pet>();
                cfg.CreateMap<Pet, PetDTO>();
            });
            var mapper = new Mapper(config);
            var EFPet = mapper.Map<Pet>(obj);
            var result = DataAccessFactory.PetDataAccess().Add(EFPet);

            return mapper.Map<PetDTO>(result);
        }
        public static PetDTO EditPet(PetDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PetDTO, Pet>();
                cfg.CreateMap<Pet, PetDTO>();
            });
            var mapper = new Mapper(config);
            var EFPet = mapper.Map<Pet>(obj);
            var result = DataAccessFactory.PetDataAccess().Update(EFPet);
            var DTOPet = mapper.Map<PetDTO>(obj);

            return DTOPet;
        }
        public static bool DeletePet(PetDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PetDTO, Pet>();
                cfg.CreateMap<Pet, PetDTO>();
            });
            var mapper = new Mapper(config);
            var EFPet = mapper.Map<Pet>(obj);
            var result = DataAccessFactory.PetDataAccess().Delete(EFPet);
            return result;
        }

        public static bool DeletePetFromTable(PetDTO obj)
        {
            var data = GetPet(obj.Id);
            if(DeletePet(data))
            {
                return true;
            }
            return false;
        }

    }
}
