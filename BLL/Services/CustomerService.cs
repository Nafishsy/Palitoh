﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerService
    {
<<<<<<< Updated upstream
=======
        public static List<CustomerDTO> GetAllCustomers()
        {
            var data = DataAccessFactory.CustomerDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDTO>());
            var mapper = new Mapper(config);
            var DTOCustomers = mapper.Map<List<CustomerDTO>>(data);
            return DTOCustomers;
        }
        public static CustomerDTO GetCustomer(int id)
        {
            var data = DataAccessFactory.CustomerDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDTO>());
            var mapper = new Mapper(config);
            var DTOCustomer = mapper.Map<CustomerDTO>(data);
            return DTOCustomer;
        }
        public static CustomerDTO AddCustomer(CustomerDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CustomerDTO, Customer>();
                cfg.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);
            var EFCustomer = mapper.Map<Customer>(obj);
            var result = DataAccessFactory.CustomerDataAccess().Add(EFCustomer);

            return mapper.Map<CustomerDTO>(result);
        }
        public static CustomerDTO EditCustomer(CustomerDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CustomerDTO, Customer>();
                cfg.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);
            var EFCustomer = mapper.Map<Customer>(obj);
            var result = DataAccessFactory.CustomerDataAccess().Update(EFCustomer);
            var DTOCustomer = mapper.Map<CustomerDTO>(obj);

            return DTOCustomer;
        }
        public static bool DeleteCustomer(CustomerDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CustomerDTO, Customer>();
                cfg.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);
            var EFCustomer = mapper.Map<Customer>(obj);
            var result = DataAccessFactory.CustomerDataAccess().Delete(EFCustomer);
            return result;
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

>>>>>>> Stashed changes
    }
}
