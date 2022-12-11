using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class VetsCustomerDTO : VetDTO
    {
        public virtual List<MapCustomerVetDTO> MapCustomerVets { get; set; }
        public VetsCustomerDTO()
        {
            MapCustomerVets = new List<MapCustomerVetDTO>();
        }
    }
}
