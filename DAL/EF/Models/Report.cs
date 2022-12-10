using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Report
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }



        [Required]
        [StringLength(100, ErrorMessage = "Description should contain no more than 100 charecters")]
        public string Description { get; set; }
    }
}
