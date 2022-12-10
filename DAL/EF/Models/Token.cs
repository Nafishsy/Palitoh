using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Token
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }



        public string AccessToken { get; set; }



        public DateTime CreatedAt { get; set; }



        public DateTime? ExpiredAt { get; set; }
    }
}
