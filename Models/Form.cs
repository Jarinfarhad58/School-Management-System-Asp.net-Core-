using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System_Practicum.Models
{
    public class Form
        
        {
       
    [Key]
        public int FormId { get; set; }
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Insert Alphabets only")]
        [Required(ErrorMessage = "This Field is Required")]
    [DisplayName("Student Name")]
    public string StudentName { get; set; }
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Insert Alphabets only")]
        [Required(ErrorMessage = "This Field is Required")]
    [DisplayName("Fathers Name")]
    public string FathersName { get; set; }
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Insert Alphabets only")]
        [Required(ErrorMessage = "This Field is Required")]
    [DisplayName("Mothers Name")]
    public string MothersName { get; set; }
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Insert Alphabets only")]
        public string Village { get; set; }
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Insert Alphabets only")]
        [DisplayName("Post Office")]
    public string PostOffice { get; set; }
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Insert Alphabets only")]
        public string Thana { get; set; }
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Insert Alphabets only")]
        [DisplayName("Zila")]
        public string Jila { get; set; }
        [RegularExpression(@"^(01)[3456789][0-9]{8}$", ErrorMessage = "Insert Valid Phone Number")]
        [Required(ErrorMessage = "This Field is Required")]
    public string Mobile { get; set; }
    [Required(ErrorMessage = "This Field is Required")]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Date Of Birth")]
    public string Birthday { get; set; }
       
    }
}
