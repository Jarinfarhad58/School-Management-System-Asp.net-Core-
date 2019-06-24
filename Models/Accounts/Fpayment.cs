using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System_Practicum.Models
{
    public class Fpayment
{
        [Key]
        public int PaymentId { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [DisplayName("Amount")]
        [RegularExpression(@"^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$", ErrorMessage = "Insert Valid input")]
        public string amount { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [DisplayName("Date")]
        public string date { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [DisplayName("User Name")]
        public string UserName { get; set; }

    }
}
