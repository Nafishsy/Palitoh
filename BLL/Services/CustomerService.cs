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
    public class CustomerService
    {
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
        public static object SearchCutomser(string name) 
            //object return korsi karon ami annonymous er modhe ak sathe duita data rakhsi, akt data er jonno notun DTO na banay
            //name dile name ashbe customerDTO dile customer er object er shob properties use korte parar kotha
        {
            var AllAccounts = AccountService.GetAllAccounts();
            var userName = (from dt in AllAccounts
                            where dt.Name.ToLower().StartsWith(name.ToLower()) && dt.Type == "Customer"
                            select dt).SingleOrDefault();

            if(userName == null)
                return null;
            else
            {
                var userInfo = (from dt in GetAllCustomers()
                                where dt.Id == userName.Id
                                select dt).SingleOrDefault();

                var obj = new { name = userName.Name, CustomerDTO = userInfo };
                return obj;
            }
            
        }
    }
}
