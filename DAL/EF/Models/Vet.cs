using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Vet
    {
        [Required]
        public int Id { get; set; }



        [Required]
        public string Designation { get; set; }



        [Required]
        public string Location { get; set; }



        [Required]
        public float AppointmentFees { get; set; }



        public virtual List<MapCustomerVet> MapCustomerVets { get; set; }
        public Vet()
        {
            MapCustomerVets = new List<MapCustomerVet>();
        }
    }
}
