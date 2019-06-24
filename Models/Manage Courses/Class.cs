using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System_Practicum.Models
{
    public class Class
{
    [Key]
    public int ClassId { get; set; }
    [Required(ErrorMessage = "This Field is Required")]
    [Display(Name = "Class")]
    public string CName { get; set; }
}
}
