using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AccountTokensDTO : AccountDTO
    {
        public virtual List<TokenDTO> Tokens { get; set; }
        public AccountTokensDTO()
        {
            Tokens = new List<TokenDTO>();
        }
    }
}
