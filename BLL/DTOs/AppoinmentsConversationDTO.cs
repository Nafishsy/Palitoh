using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AppoinmentsConversationDTO : MapCustomerVetDTO
    {
        public virtual List<Conversation> Conversations { get; set; }

        public AppoinmentsConversationDTO()
        {
            Conversations = new List<Conversation>();
        }
    }
}
