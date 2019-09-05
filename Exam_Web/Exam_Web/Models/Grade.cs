using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Web.Models
{
    public class Grade
    {
        [Key]
        public int Gra_id { get; set; }

        public string Stu_id { get; set; }

        public int Test_id { get; set; }

        public int S_mark { get; set; }

        public int A_mark { get; set; }

        public int mark { get; set; }

        public string T_id { get; set; }

        public int Answer_id { get; set; }

    }
}
