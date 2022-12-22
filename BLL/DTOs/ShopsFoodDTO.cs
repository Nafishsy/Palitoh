using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ShopsFoodDTO : ShopDTO
    {
        public virtual List<FoodDTO> Foods { get; set; }
        public ShopsFoodDTO()
        {
            Foods = new List<FoodDTO>();
        }
    }
}
