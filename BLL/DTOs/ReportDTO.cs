using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReportDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Description { get; set; }
    }
}
