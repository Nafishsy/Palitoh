using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MapCustomerFoodDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int FoodId { get; set; }
        public int? EmployeeId { get; set; }
        public int OrderId { get; set; }
        public DateTime RequestItemTime { get; set; }
    }
}
