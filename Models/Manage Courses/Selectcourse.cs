using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System_Practicum.Models
{
    public class Selectcourse
{
    [Key]
        public int Courseid { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
    [DisplayName("Faculty User Name")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "This Field is Required")]


    [DisplayName("Select Subject Name")]
    public int SubjectId { get; set; }
    [Required(ErrorMessage = "This Field is Required")]
    [DisplayName("Select Class")]
    public int ClassId { get; set; }
    [Required(ErrorMessage = "This Field is Required")]
    [DisplayName("Select Time")]
    public int TimeId { get; set; }

    [Required(ErrorMessage = "This Field is Required")]
    [DisplayName("Day")]
    public string Country { get; set; }
    [NotMapped]
    public List<SelectListItem> Countries { get; } = new List<SelectListItem>
        {
             new SelectListItem { Value = "", Text = "--Select--" },
            new SelectListItem { Value = "Sunday", Text = "Sunday" },
            new SelectListItem { Value = "Monday", Text = "Monday" },
            new SelectListItem { Value = "Tuesday", Text = "Tuesday"  },
             new SelectListItem { Value = "Wednesday", Text = "Wednesday"  },
              new SelectListItem { Value = "Thursday", Text = "Thursday"  },
        };
        public virtual Class Class { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Time Time { get; set; }
       
    }
}
