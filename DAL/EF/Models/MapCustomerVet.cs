using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class MapCustomerVet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        [Required]
        public DateTime AppointmentDate { get; set; }



        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }



        [ForeignKey("Vet")]
        public int VetId { get; set; }
        public virtual Vet Vet { get; set; }


        public virtual List<Conversation> Conversation { get; set; }
        public MapCustomerVet()
        {
            Conversation = new List<Conversation>();
        }
    }
}
