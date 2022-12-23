using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BLL.Services
{
    public class MapCustomerFoodService
    {
        public static List<MapCustomerFoodDTO> GetAllMapCustomerFoods()
        {
            var data = DataAccessFactory.MapCustomerFoodDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MapCustomerFood, MapCustomerFoodDTO>());
            var mapper = new Mapper(config);
            var DTOMapCustomerFoods = mapper.Map<List<MapCustomerFoodDTO>>(data);
            return DTOMapCustomerFoods;
        }
        public static MapCustomerFoodDTO GetMapCustomerFood(int id)
        {
            var data = DataAccessFactory.MapCustomerFoodDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MapCustomerFood, MapCustomerFoodDTO>());
            var mapper = new Mapper(config);
            var DTOMapCustomerFood = mapper.Map<MapCustomerFoodDTO>(data);
            return DTOMapCustomerFood;
        }
        public static MapCustomerFoodDTO AddMapCustomerFood(MapCustomerFoodDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<MapCustomerFoodDTO, MapCustomerFood>();
                cfg.CreateMap<MapCustomerFood, MapCustomerFoodDTO>();
            });
            var mapper = new Mapper(config);
            var EFMapCustomerFood = mapper.Map<MapCustomerFood>(obj);
            var result = DataAccessFactory.MapCustomerFoodDataAccess().Add(EFMapCustomerFood);

            return mapper.Map<MapCustomerFoodDTO>(result);
        }
        public static MapCustomerFoodDTO EditMapCustomerFood(MapCustomerFoodDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<MapCustomerFoodDTO, MapCustomerFood>();
                cfg.CreateMap<MapCustomerFood, MapCustomerFoodDTO>();
            });
            var mapper = new Mapper(config);
            var EFMapCustomerFood = mapper.Map<MapCustomerFood>(obj);
            var result = DataAccessFactory.MapCustomerFoodDataAccess().Update(EFMapCustomerFood);
            var DTOMapCustomerFood = mapper.Map<MapCustomerFoodDTO>(obj);

            return DTOMapCustomerFood;
        }
        public static bool DeleteMapCustomerFood(MapCustomerFoodDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<MapCustomerFoodDTO, MapCustomerFood>();
                cfg.CreateMap<MapCustomerFood, MapCustomerFoodDTO>();
            });
            var mapper = new Mapper(config);
            var EFMapCustomerFood = mapper.Map<MapCustomerFood>(obj);
            var result = DataAccessFactory.MapCustomerFoodDataAccess().Delete(EFMapCustomerFood);
            return result;
        }

        public static bool addOrder(List<int> ids)
        {
            bool result = true;
            foreach (var id in ids)
            {
                MapCustomerFoodDTO order = new MapCustomerFoodDTO();
                order.OrderId = 2;
                order.EmployeeId = null;
                order.CustomerId = 1;
                order.FoodId = id;
                order.RequestItemTime = System.DateTime.Now.AddDays(2);

                if(AddMapCustomerFood(order)==null)
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
