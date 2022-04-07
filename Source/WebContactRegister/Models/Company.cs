using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebContactRegister.Models
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }
        [Required]
        [StringLength(20)]
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public virtual List<Person> Persons { get; set; } = new List<Person>();//details
    }
}
