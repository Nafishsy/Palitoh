using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        [Required]
        //[StringLength(50, MinimumLength = 3, ErrorMessage = "Name should contain 3 to 50 characters")]
        //[RegularExpression(@"^[a-zA-Z\s\.\-]*$", ErrorMessage = "Use letters/dashes/spaces/dots only please")]
        public string Name { get; set; }



        [Required]
        //[StringLength(15, MinimumLength = 3, ErrorMessage = "Username should contain 3 to 15 characters")]
        public string UserName { get; set; }



        [Required]
        //[RegularExpression(@"^.*(?=.{3,})(?=.*[a-zA-Z])(?=.*[0-9])(?=.*[\d])(?=.*[@!$#%]).*$", ErrorMessage = "Password should contain at least 1 uppercase, 1 lowercase, 1 special character and 1 number")]
        //[StringLength(100, MinimumLength = 8, ErrorMessage = "Password should contain 8 to 100 characters")]
        public string Password { get; set; }



        public string Type { get; set; }



        public string ProfilePic { get; set; }



        public string Status { get; set; }



        public virtual List<Token> Tokens { get; set; }
        public virtual List<Report> Reports { get; set; }
        public Account()
        {
            Tokens = new List<Token>();
            Reports = new List<Report>();
        }
    }
}
