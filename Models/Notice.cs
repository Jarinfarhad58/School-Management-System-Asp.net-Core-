using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System_Practicum.Models
{
    public class Notice
{
        [Key]
        
        public int NoticeID { get; set; }
        [Required(ErrorMessage = "Notice Title is Required")]
        [DisplayName("Notice Title")]
        public string NoticeTitle { get; set; }
        [Required(ErrorMessage = "Choosing a file is Required")]
        public string pic { get; set; }
    }
}
