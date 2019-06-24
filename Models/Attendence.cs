using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System_Practicum.Models
{
    public class Attendence
{
        [Key]
        public int id { get; set; }
        [DisplayName("Date")]
        public string date { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }


    }
}
