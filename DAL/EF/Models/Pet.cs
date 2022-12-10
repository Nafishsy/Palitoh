using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Pet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        [Required]
        public string Name { get; set; }



        [Required]
        public string Type { get; set; }



        [Required]
        public string Gender { get; set; }



        [Required]
        public string Age { get; set; }



        [Required]
        public string Status { get; set; }



        [ForeignKey("Shop")]
        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }



        public virtual List<MapCustomerPet> MapCustomerPets { get; set; }
        public Pet()
        {
            MapCustomerPets = new List<MapCustomerPet>();
        }
    }
}
