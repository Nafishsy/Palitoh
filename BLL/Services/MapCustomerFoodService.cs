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
using System.Xml.Linq;

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

        public static bool addOrder(List<int> ids,int C_id)
        {
            bool result = true;
            MapCustomerFoodDTO LastOrder = MapCustomerFoodService.GetAllMapCustomerFoods().LastOrDefault((e)=> e.OrderId>0);
            int OrderID;
            if(LastOrder==null)
            {
                OrderID = 0;
            }
            else
            {
                OrderID = LastOrder.OrderId;
            }
            foreach (var id in ids)
            {
                MapCustomerFoodDTO order = new MapCustomerFoodDTO();
                order.OrderId = OrderID + 1;
                order.EmployeeId = null;
                order.CustomerId = C_id;
                order.FoodId = id;
                order.RequestItemTime = System.DateTime.Now.AddDays(2);

                if(AddMapCustomerFood(order)==null)
                {
                    result = false;
                }
            }
            return result;
        }
        public static object GetAllCartCustomer(int id)
        {
            var data = GetAllMapCustomerFoods();
            var history = (from dt in data
                           join ac in FoodService.GetAllFoods() on dt.FoodId equals ac.Id
                           orderby dt.OrderId
                           where dt.CustomerId == id
                           select new { FoodName = ac.Name, Date = dt.RequestItemTime, Id = dt.OrderId }).ToList();
            return history;
        }
      
    }
}
