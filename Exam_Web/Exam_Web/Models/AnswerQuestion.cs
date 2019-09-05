using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Web.Models
{
    public class AnswerQuestion
    {
        [Key]
        public int AQ_ID { get; set; }

        public string AQ_Name { get; set; }
        public string AQ_Teacher { get; set; }
        public string AQ_Desc { get; set; }
        public string AQ_Class { get; set; }
        public int AQ_Mark {get;set;}
    }
}
