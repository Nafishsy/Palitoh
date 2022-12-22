using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AccountReportsDTO : AccountDTO
    {
        public virtual List<ReportDTO> Reports { get; set; }
        public AccountReportsDTO()
        {
            Reports = new List<ReportDTO>();
        }
    }
}
