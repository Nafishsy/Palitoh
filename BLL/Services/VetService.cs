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


    }
}
