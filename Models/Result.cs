using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System_Practicum.Models
{
    public class Result
{
        [Key]
        [Required(ErrorMessage = "This Field is Required")]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [RegularExpression(@"^(100|[1-9]?[0-9])$", ErrorMessage = "Number Should be 0-100")]
        [Required(ErrorMessage = "This Field is Required")]
        [DisplayName("Bangla")]
        public string Bngla { get; set; }
        [RegularExpression(@"^(100|[1-9]?[0-9])$", ErrorMessage = "Number Should be 0-100")]
        [DisplayName("English")]
        public string English { get; set; }
        [RegularExpression(@"^(100|[1-9]?[0-9])$", ErrorMessage = "Number Should be 0-100")]
        [DisplayName("Mathematics")]
        public string Mathmatics { get; set; }
        [RegularExpression(@"^(100|[1-9]?[0-9])$", ErrorMessage = "Number Should be 0-100")]
        [DisplayName("Science")]
        public string Science { get; set; }
        [RegularExpression(@"^(100|[1-9]?[0-9])$", ErrorMessage = "Number Should be 0-100")]
        [DisplayName("Religion")]
        public string Religion { get; set; }
        [RegularExpression(@"^(100|[1-9]?[0-9])$", ErrorMessage = "Number Should be 0-100")]
        [DisplayName("Bangla")]
        public string Bnglam { get; set; }
        [RegularExpression(@"^(100|[1-9]?[0-9])$", ErrorMessage = "Number Should be 0-100")]
        [DisplayName("English")]
        public string Englishm { get; set; }
        [RegularExpression(@"^(100|[1-9]?[0-9])$", ErrorMessage = "Number Should be 0-100")]
        [DisplayName("Mathematics")]
        public string Mathmaticsm { get; set; }
        [RegularExpression(@"^(100|[1-9]?[0-9])$", ErrorMessage = "Number Should be 0-100")]
        [DisplayName("Science")]
        public string Sciencem { get; set; }
        [RegularExpression(@"^(100|[1-9]?[0-9])$", ErrorMessage = "Number Should be 0-100")]
        [DisplayName("Religion")]
        public string Religionm { get; set; }

    }
}
