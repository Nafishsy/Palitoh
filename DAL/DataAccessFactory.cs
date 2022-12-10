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
    internal class DataAccessFactory
    {
        public static IRepo<MapCustomerVet, int, MapCustomerVet> MapCustomerVetDataAccess()
        {
            return new MapCustomerVetRepo();
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
    }
}
