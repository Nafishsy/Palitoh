using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ShopsPetDTO : ShopDTO
    {
        public virtual List<PetDTO> Pets { get; set; }
        public ShopsPetDTO()
        {
            Pets = new List<PetDTO>();
        }
    }
}
