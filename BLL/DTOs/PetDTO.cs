using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Status { get; set; }
        public int ShopId { get; set; }
    }
}
