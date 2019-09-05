using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Web.Models
{
    public class SelectQuestions
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Que_ID { get; set; }
        public string Que_name { get; set; }
        public int Que_mark { get; set; }
        public string First_select { get; set; }
        public string Second_select { get; set; }
        public string Third_select { get; set; }
        public string Fourth_select { get; set; }
        //public string Que_Select { get; set; }//用join方法
        public string Answer { get; set; }//split方法
        public string Dec { get; set; }
        public int Difficulty { get; set; }
        public string Que_Class { get; set; }
        public string Que_major { get; set; }


    }
}
