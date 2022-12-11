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
    internal class CustomerService
    {
        public static CustomerDTO Add(CustomerDTO customer)
        {
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<CustomerDTO, Customer>();
                c.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(cfg);
            var cstmer = mapper.Map<Customer>(customer);
            var data = DataAccessFactory.CustomerDataAccess().Add(cstmer);

            if (data != null) return mapper.Map<CustomerDTO>(data);
            return null;
        }

        public static List<CustomerDTO> Get()
        {
            var data = DataAccessFactory.CustomerDataAccess().Get();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomerDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<CustomerDTO>>(data);
        }

        public static CustomerDTO Get(int id)
        {
            var data = DataAccessFactory.CustomerDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomerDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<CustomerDTO>(data);
        }

        public static CustomersFoodDTO GetwithFood(int id)
        {
            //Customer ki ki food kinse seitar list //not done properly
            var data = DataAccessFactory.CustomerDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomersFoodDTO>();
                c.CreateMap<Food, FoodDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<CustomersFoodDTO>(data);
        }

        public static CustomersPetDTO GetwithPet(int id)
        {
            //Customer ki ki pet kinse seitar list //not done properly
            var data = DataAccessFactory.CustomerDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomersPetDTO>();
                c.CreateMap<Pet, PetDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<CustomersPetDTO>(data);
        }

        public static CustomersVetDTO GetwithVet(int id)
        {
            //Customer ki ki vet appoint korse seitar list //not done properly
            var data = DataAccessFactory.CustomerDataAccess().Get(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Customer, CustomersVetDTO>();
                c.CreateMap<Vet, VetDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<CustomersVetDTO>(data);
        }

    }
}
