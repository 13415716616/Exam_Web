using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Web.Models
{
    public class Answer
    {
        [Key]
        public int A_ID { get; set; }
        public string Stu_ID { get; set; }
        public int Test_ID { get; set; }
        public string A_an { get; set; }
        public string S_an { get; set; }
        public int grade_id { get; set; }
    }
}
