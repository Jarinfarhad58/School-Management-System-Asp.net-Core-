using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System_Practicum.Models
{
    public class Resultclass
{
        [Key]
        [DisplayName("Class")]
        public string Class { get; set; }
    }
}
