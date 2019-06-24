using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Management_System_Practicum.Models
{
    public class Image
{
        [Key]
        
        public int ImageID { get; set; }
        [DisplayName("Image Title")]
        [Required(ErrorMessage = "Image Title is Required")]
        public string ImageTitle { get; set; }
        [Required(ErrorMessage = "You need to choose a picture First")]
        public string pic { get; set; }
    }
}
