using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Web.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Class_ID { get; set; }

        public string Class_name { get; set; }

        public string Class_Teacher { get; set; }

        public string Class_academic { get; set; }

        public string Class_dec { get; set; }

        public string Class_major { get; set; }
    }
}
