using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MapCustomerVetDTO
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int CustomerId { get; set; }
        public int VetId { get; set; }
    }
}
