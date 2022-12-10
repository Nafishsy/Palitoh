using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }



        [Required]
        public string Location { get; set; }



        [Required]
        public float Balance { get; set; }



        public virtual List<MapCustomerFood> MapCustomerFoods { get; set; }
        public virtual List<MapCustomerVet> MapCustomerVets { get; set; }
        public virtual List<MapCustomerPet> MapCustomerPets { get; set; }
        public Customer()
        {
            MapCustomerFoods = new List<MapCustomerFood>();
            MapCustomerVets = new List<MapCustomerVet>();
            MapCustomerPets = new List<MapCustomerPet>();
        }
    }
}
