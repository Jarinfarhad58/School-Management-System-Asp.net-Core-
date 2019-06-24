using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System_Practicum.Models
{
    public class Time
{
        [Key]
        public int TimeId { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Time")]
        public string TName { get; set; }
    }
}
