using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System_Practicum.Models
{
    public class Addinfo
   {
        [Key]
        [Required(ErrorMessage = "This Field is Required")]
        [DisplayName("Add  Information ")]
        public string msg { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [DisplayName("Information No")]
        public string msgno { get; set; }
    }
}
