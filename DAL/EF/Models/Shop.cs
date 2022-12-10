using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Shop
    {
        [Required]
        public int Id { get; set; }



        [Required]
        public string Location { get; set; }



        public virtual List<Pet> Pets { get; set; }
        public virtual List<Employee> Employees { get; set; }
        public virtual List<Food> Foods { get; set; }
        public Shop()
        {
            Pets = new List<Pet>();
            Employees = new List<Employee>();
            Foods = new List<Food>();
        }
    }
}
