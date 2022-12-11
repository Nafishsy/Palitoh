using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CustomersVetDTO : CustomerDTO
    {
        public virtual List<MapCustomerVetDTO> MapCustomerVets { get; set; }
        public CustomersVetDTO()
        {
            MapCustomerVets = new List<MapCustomerVetDTO>();
        }
    }
}
