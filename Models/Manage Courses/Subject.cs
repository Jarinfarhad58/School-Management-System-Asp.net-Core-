using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System_Practicum.Models
{
    public class Subject
{
        [Key]
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Subject Name")]
        public string SName { get; set; }
    }
}
