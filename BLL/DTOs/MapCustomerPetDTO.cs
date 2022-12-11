using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MapCustomerPetDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PetId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime AdoptionRequestTime { get; set; }
    }
}
