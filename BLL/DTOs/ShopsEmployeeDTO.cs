using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ShopsEmployeeDTO : ShopDTO
    {
        public virtual List<EmployeeDTO> Employees { get; set; }
        public ShopsEmployeeDTO()
        {
            Employees = new List<EmployeeDTO>();
        }
    }
}
