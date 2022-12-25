using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class PalitohContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<MapCustomerFood> MapCustomerFoods { get; set; }
        public DbSet<MapCustomerPet> MapCustomerPets { get; set; }
        public DbSet<MapCustomerVet> MapCustomerVets { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<Conversation> Conversations { get; set; }

    }
}
