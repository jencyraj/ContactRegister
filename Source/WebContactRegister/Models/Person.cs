using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebContactRegister.Models
{
    public class Person
    {
        [Key]
        public int PID { get; set; }
        [ForeignKey("Company")]
        public int CID { get; set; }
        public virtual Company Company { get; private set; } //Very Important
        [Required(ErrorMessage ="Please enter the name! ")]
        [Display(Name = "Name")]
        [StringLength(20)]
        public string Name { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }
        [NotMapped]
        public bool IsDeleted { get; set; } = false;
    }
}
