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
    public class Registration
        {[Key]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$",ErrorMessage ="Insert Alphabets only" )]
        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        public String FirstName { get; set; }

        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Insert Alphabets only")]
        [DisplayName("Last Name")]
        public String LastName { get; set; }

       
        [Required(ErrorMessage = "User Type is Required")]
        [DisplayName("User Type")]
        public string Country { get; set; }
        [Required(ErrorMessage = "User Type is Required")]
        [NotMapped]
        public List<SelectListItem> Countries { get; } = new List<SelectListItem>
        {
             new SelectListItem { Value = "", Text = "--Select--" },
            new SelectListItem { Value = "1", Text = "Admin" },
            new SelectListItem { Value = "2", Text = "Faculty" },
            new SelectListItem { Value = "3", Text = "Student"  },
        };
        [RegularExpression(@"^(A|B|AB|O)[-+]$", ErrorMessage = "Insert Valid Blood Group")]
        [DisplayName("Blood Group")]
        public String BloodGroup { get; set; }

        
        [DisplayName("Class")]
        public String Class { get; set; }


        [RegularExpression(@"^(01)[3456789][0-9]{8}$", ErrorMessage = "Insert Valid Phone Number")]
        [DisplayName("Mobile Number")]
        public String MobileNumber { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "This Field is Required")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public String UserName { get; set; }

        
        [Required(ErrorMessage = "This Field is Required")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Required(ErrorMessage = "This Field is Required")]

        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Password didn't match")]
        public String ConfirmPassword { get; set; }
       
    }
}
