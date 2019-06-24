using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System_Practicum.Models
{
    public class User
    
{
        [Key]

        
        public int UserID { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage = "This Field is Required")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This Field is Required")]
        public string Password { get; set; }
    }
}
