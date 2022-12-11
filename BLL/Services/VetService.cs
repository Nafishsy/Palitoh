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
    internal class VetService
    {
        public static VetDTO Add(VetDTO veternarian)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<VetDTO, Vet>();
                c.CreateMap<Vet, VetDTO>();
            });
            var mapper = new Mapper(cfg);
            var vet = mapper.Map<Vet>(veternarian);
            var data = DataAccessFactory.VetDataAccess().Add(vet);

            if (data != null) return mapper.Map<VetDTO>(data);
            return null;
        }

        public static List<VetDTO> Get()
        {
            var data = DataAccessFactory.VetDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Vet, VetDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<VetDTO>>(data);
        }

        public static VetDTO Get(int id)
        {
            var data = DataAccessFactory.VetDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Vet, VetDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<VetDTO>(data);
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


    }
}
