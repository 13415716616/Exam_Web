using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Web.Models
{
    public class Students
    {
        [Key]
        [Display(Name ="账号")]
        [Required]
        public string student_id { get; set; }

        [Required]
        [Display(Name ="用户名")]
        public string student_name { get; set; }

        [Required]
        [Display(Name ="密码")]
        public string student_password { get; set; }

        [Display(Name ="邮箱")]
        [DataType(DataType.EmailAddress)]
        public string student_email { get; set; }

        public string student_sex { get; set; }

        public DateTime student_time { get; set; }

        public string student_class { get; set; }

        public string student_img { get; set; }

        public string student_birthday { get; set; }

        public string student_year { get; set; }

        public string student_dec { get; set; }

        [NotMapped]
        public IFormFile imgfile { get; set; }
    }
}
