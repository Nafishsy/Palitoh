using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<MapCustomerVet, int, MapCustomerVet> MapCustomerVetDataAccess()
        {
            return new MapCustomerVetRepo();
        }
        public static IRepo<Conversation, int, Conversation> ConversationDataAccess()
        {
            return new ConversationRepo();
        }
        public static IRepo<MapCustomerFood, int, MapCustomerFood> MapCustomerFoodDataAccess()
        {
            return new MapCustomerFoodRepo();
        }

        public static IRepo<MapCustomerPet, int, MapCustomerPet> MapCustomerPetDataAccess()
        {
            return new MapCustomerPetRepo();
        }
        public static IRepo<Vet, int, Vet> VetDataAccess()
        {
            return new VetRepo();
        }

        public static IRepo<Customer, int, Customer> CustomerDataAccess()
        {
            return new CustomerRepo();
        }
        public static IRepo<Account, int, Account> AccountDataAccess()
        {
            return new AccountRepo();
        }
        public static IRepo<Admin, int, Admin> AdminDataAccess()
        {
            return new AdminRepo();
        }
        public static IRepo<Employee, int, Employee> EmployeeDataAccess()
        {
            return new EmployeeRepo();
        }
        public static IRepo<Food, int, Food> FoodDataAccess()
        {
            return new FoodRepo();
        }
        public static IRepo<Pet, int, Pet> PetDataAccess()
        {
            return new PetRepo();
        }
        public static IRepo<Report, int, Report> ReportDataAccess()
        {
            return new ReportRepo();
        }
        public static IRepo<Shop, int, Shop> ShopDataAccess()
        {
            return new ShopRepo();
        }
        public static IRepo<Token, int, Token> TokenDataAccess()
        {
            return new TokenRepo();
        }
        public static IAuth AuthDataAccess()
        {
            return new AccountRepo();
        }
    }
}
