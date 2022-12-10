using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        [Required]
        public string Name { get; set; }



        [Required]
        public string Designation { get; set; }



        [Required]
        public string Location { get; set; }



        [Required]
        public string WorkingHour { get; set; }



        [ForeignKey("Shop")]
        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }



        public virtual List<MapCustomerPet> MapCustomerPets { get; set; }
        public virtual List<MapCustomerFood> MapCustomerFoods { get; set; }
        public Employee()
        {
            MapCustomerPets = new List<MapCustomerPet>();
            MapCustomerFoods = new List<MapCustomerFood>();
        }
    }
}
