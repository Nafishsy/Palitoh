using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class VetDTO
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public string Location { get; set; }
        public float AppointmentFees { get; set; }

    }
}
