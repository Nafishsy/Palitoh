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
    public class FoodService
    {
        public static List<FoodDTO> GetAllFoods()
        {
            var data = DataAccessFactory.FoodDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Food, FoodDTO>());
            var mapper = new Mapper(config);
            var DTOFoods = mapper.Map<List<FoodDTO>>(data);
            return DTOFoods;
        }
        public static FoodDTO GetFood(int id)
        {
            var data = DataAccessFactory.FoodDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Food, FoodDTO>());
            var mapper = new Mapper(config);
            var DTOFood = mapper.Map<FoodDTO>(data);
            return DTOFood;
        }
        public static FoodDTO AddFood(FoodDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<FoodDTO, Food>();
                cfg.CreateMap<Food, FoodDTO>();
            });
            var mapper = new Mapper(config);
            var EFFood = mapper.Map<Food>(obj);
            var result = DataAccessFactory.FoodDataAccess().Add(EFFood);

            return mapper.Map<FoodDTO>(result);
        }
        public static FoodDTO EditFood(FoodDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<FoodDTO, Food>();
                cfg.CreateMap<Food, FoodDTO>();
            });
            var mapper = new Mapper(config);
            var EFFood = mapper.Map<Food>(obj);
            var result = DataAccessFactory.FoodDataAccess().Update(EFFood);
            var DTOFood = mapper.Map<FoodDTO>(obj);

            return DTOFood;
        }
        public static bool DeleteFood(FoodDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<FoodDTO, Food>();
                cfg.CreateMap<Food, FoodDTO>();
            });
            var mapper = new Mapper(config);
            var EFFood = mapper.Map<Food>(obj);
            var result = DataAccessFactory.FoodDataAccess().Delete(EFFood);
            return result;
        }

        public static List<FoodDTO> SearchFood(string name)
        {
            var data = GetAllFoods();

            var dt= (from d in data
                     where d.Name.ToLower().StartsWith(name.ToLower())
                     select d).ToList();

            return dt;
        }
    }
}
