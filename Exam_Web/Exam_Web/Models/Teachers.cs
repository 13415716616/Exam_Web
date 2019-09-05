using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Web.Models
{
    public class Teachers
    {
        [Key]
        [Required]
        public string Teacher_id { get; set; }
        public string Teacher_name { get; set; }
        public string Teacher_password { get; set; }
        public string Teacher_class { get; set; }

        [DataType(DataType.Date)]
        public DateTime Teacher_time { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Teacher_email { get; set; }

        public string Teacher_dec { get; set; }

        public int Teacher_year { get; set; }
        public string Teacher_birthday { get; set; }
        public string Teacher_sex { get; set;}
        public string Teacher_img { get; set; }

        [NotMapped]
        public IFormFile imgfile { get; set; }
    }
}
