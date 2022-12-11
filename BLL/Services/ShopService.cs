﻿using AutoMapper;
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
    public class ShopService
    {
        public static List<ShopDTO> GetAllShops()
        {
            var data = DataAccessFactory.ShopDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Shop, ShopDTO>());
            var mapper = new Mapper(config);
            var DTOShops = mapper.Map<List<ShopDTO>>(data);
            return DTOShops;
        }
        public static ShopDTO GetShop(int id)
        {
            var data = DataAccessFactory.ShopDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Shop, ShopDTO>());
            var mapper = new Mapper(config);
            var DTOShop = mapper.Map<ShopDTO>(data);
            return DTOShop;
        }
        public static ShopDTO AddShop(ShopDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShopDTO, Shop>();
                cfg.CreateMap<Shop, ShopDTO>();
            });
            var mapper = new Mapper(config);
            var EFShop = mapper.Map<Shop>(obj);
            var result = DataAccessFactory.ShopDataAccess().Add(EFShop);

            return mapper.Map<ShopDTO>(result);
        }
        public static ShopDTO EditShop(ShopDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShopDTO, Shop>();
                cfg.CreateMap<Shop, ShopDTO>();
            });
            var mapper = new Mapper(config);
            var EFShop = mapper.Map<Shop>(obj);
            var result = DataAccessFactory.ShopDataAccess().Update(EFShop);
            var DTOShop = mapper.Map<ShopDTO>(obj);

            return DTOShop;
        }
        public static bool DeleteShop(ShopDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ShopDTO, Shop>();
                cfg.CreateMap<Shop, ShopDTO>();
            });
            var mapper = new Mapper(config);
            var EFShop = mapper.Map<Shop>(obj);
            var result = DataAccessFactory.ShopDataAccess().Delete(EFShop);
            return result;
        }
    }
}
