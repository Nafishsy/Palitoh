using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CustomersFoodDTO : CustomerDTO
    {
        public virtual List<MapCustomerFoodDTO> MapCustomerFoods { get; set; }

        public CustomersFoodDTO()
        {
            MapCustomerFoods = new List<MapCustomerFoodDTO>();
        }
    }
}
