using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Food
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        [Required]
        public string Name { get; set; }



        [Required]
        public int Amount { get; set; }



        [Required]
        public string Status { get; set; }



        [Required]
        public float Price { get; set; }



        [ForeignKey("Shop")]
        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }



        public virtual List<MapCustomerFood> MapCustomerFoods { get; set; }
        public Food()
        {
            MapCustomerFoods = new List<MapCustomerFood>();
        }
    }
}
