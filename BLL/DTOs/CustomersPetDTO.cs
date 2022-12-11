using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CustomersPetDTO : CustomerDTO
    {
        public virtual List<MapCustomerPetDTO> MapCustomerPets { get; set; }
        public CustomersPetDTO()
        {
            MapCustomerPets = new List<MapCustomerPetDTO>();
        }
    }
}
