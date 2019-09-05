using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Web.Models
{
    public class Test
    {
        [Key]
        public int Test_ID { get; set; }
        public string Test_name { get; set; }
        public string Test_Select { get; set; }
        public string Test_Answer { get; set; }
        public int Mark { get; set; }
        public string Test_Class { get; set; }
        public string Tea_id { get; set; }

    }
}
