using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Conversation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Time { get; set; }
        public int CustomerId { get; set; }

        public string Text { get; set; }
        public int VetId { get; set; }

        [ForeignKey("MapCustomerVet")]
        public int ChatId { get; set; }
        public virtual MapCustomerVet MapCustomerVet { get; set; }


    }
}
