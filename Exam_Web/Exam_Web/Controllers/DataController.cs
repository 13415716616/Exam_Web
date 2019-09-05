using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Web.Controllers
{
    public class DataController : Controller
    {
        public UserContent userContent;

        public DataController(UserContent userContent)
        {
            this.userContent = userContent;
        }

        public void DeleteClass(int id)
        {
            try
            { var data = userContent.Course.FirstOrDefault(b => b.Class_ID == id);
                userContent.Course.Remove(data);
                userContent.SaveChanges();
            }
            catch
            {
                Console.WriteLine("error");
            }
        }

        public void DeleteSelsect(int id)
        {
            try
            {
                var data = userContent.SelectQuestions.FirstOrDefault(b => b.Que_ID == id);
                userContent.SelectQuestions.Remove(data);
                userContent.SaveChanges();
            }
            catch
            {
                Console.WriteLine("error");
            }
        }

        public void DeleteAnswer(int id)
        {
            try
            {
                var data = userContent.AnswerQuestion.FirstOrDefault(b => b.AQ_ID == id);
                userContent.AnswerQuestion.Remove(data);
                userContent.SaveChanges();
            }
            catch
            {
                Console.WriteLine("error");
            }
        }


        public int CreateSelect(SelectQuestions questions)
        {
            userContent.SelectQuestions.Add(questions);
            userContent.SaveChanges();
            var id = userContent.SelectQuestions.FirstOrDefault(b => b.Que_name == questions.Que_name).Que_ID;
            return id;
        }

        public int CreateAnswer(AnswerQuestion Answer)
        {

            userContent.AnswerQuestion.Add(Answer);
            userContent.SaveChanges();
            var id = userContent.AnswerQuestion.FirstOrDefault(b => b.AQ_Name == Answer.AQ_Name).AQ_ID;
            return id;
        }

        public JsonResult GetSelect(int id)
        {
            var select= userContent.SelectQuestions.FirstOrDefault(b => b.Que_ID == id);
            return Json(select);
        }

        public JsonResult GetAnswer(int id)
        {
            var answer = userContent.AnswerQuestion.FirstOrDefault(b => b.AQ_ID == id);
            return Json(answer);
        }

        public void Test_sumit()
        {
            Test test = new Test();
            test.Test_Select= Request.Form["id"];
           // var s = new List<string>(a.Split(','));
         //   test.Test_Select = new List<int>(s.Select<string, int>(q => Convert.ToInt32(q)));
            test.Test_name = Request.Form["name"];
            test.Test_Class = Request.Form["class"];
            test.Test_Answer = Request.Form["A_id"];
            test.Mark =int.Parse(Request.Form["mark"]);
            userContent.Test.Add(test);
            userContent.SaveChanges();
            RedirectToAction("CreateTest", "Teacher");
        }

        public void ModifySelect(int mark)
        {
            var id = Request.Form["id"];
            var S_class = Request.Form["class"];      
            var Sel_name = Request.Form["name"];
            var Sel_A= Request.Form["A"];
            var Sel_B = Request.Form["B"];
            var Sel_C = Request.Form["C"];
            var Sel_D = Request.Form["D"];
            var Sel_dec = Request.Form["dec"];
            var t = userContent.SelectQuestions.FirstOrDefault(b => b.Que_ID == int.Parse(id));
            t.Que_Class = S_class;
            t.Que_name = Sel_name;
            t.First_select = Sel_A;
            t.Second_select = Sel_B;
            t.Third_select = Sel_C;
            t.Fourth_select = Sel_D;
            t.Dec = Sel_dec;
            t.Que_mark =mark;
            t.Answer = Request.Form["answer"];
            //  t=questions;
            userContent.SelectQuestions.Update(t);
            userContent.SaveChanges();

        }

        public void ModifyAnswer()
        {
            var id = Request.Form["id"];
            var A_class = Request.Form["class"];
            var A_name = Request.Form["name"];
            var A_dec = Request.Form["dec"];
            var A_mark = Request.Form["mark"];
            var a = userContent.AnswerQuestion.FirstOrDefault(b => b.AQ_ID ==int.Parse(id));
            a.AQ_Class = A_class;
            a.AQ_Name = A_name;
            a.AQ_Mark = int.Parse( A_mark);
            a.AQ_Desc = A_dec;
            userContent.AnswerQuestion.Update(a);
            userContent.SaveChanges();

        }

        public void EditGrade()
        {
            var S_mark = Request.Form["S_mark"];
            var A_marl = Request.Form["A_mark"];
            var G_mark = Request.Form["G_mark"];
            var id = Request.Form["id"];
            var a = userContent.Grades.FirstOrDefault(b => b.Gra_id ==int.Parse(id));
            a.S_mark =int.Parse(S_mark);
            a.A_mark = int.Parse(A_marl);
            a.mark = int.Parse(G_mark);
            userContent.Grades.Update(a);
            userContent.SaveChanges();
        }

        public JsonResult GetGrade(int id)
        {
            //var id = Request.Form["id"];
            var a = userContent.Grades.FirstOrDefault(b => b.Gra_id == id);
            return Json(a);
        }

        public JsonResult GetAnswerifno(int id)
        {
            try {
                var ansid = userContent.Grades.FirstOrDefault(b => b.Gra_id == id);
                var i = userContent.Answer.FirstOrDefault(b => b.grade_id == id).A_an.ToString(); //回答的问题
                var j = userContent.Grades.FirstOrDefault(a => a.Gra_id == id).Test_id;
                var s = userContent.Test.FirstOrDefault(n => n.Test_ID == j).Test_Answer.ToString();
                var answer = s.Split(",");
                string answerinfo = "";
                for (var num = 0; num < answer.Length; num++)
                {
                    answerinfo += userContent.AnswerQuestion.FirstOrDefault(b => b.AQ_ID == int.Parse(answer[num])).AQ_Name.ToString() + "&";
                }
                string allinfo = answerinfo + "-" + i;
                return Json(allinfo);
                }
            catch { string allinfo = ""; return Json(allinfo); }            
        }

        public void SaveGradeAnswer(int id,int mark)
        {
            var a = userContent.Grades.FirstOrDefault(b => b.Gra_id == id);
            //      var t= Request.Form["mark"];
            a.A_mark = mark;
            a.mark += mark;
            userContent.Grades.Update(a);
            userContent.SaveChanges();
        }

        public void editclass(Course classsett)
        {
            var a = userContent.Course.FirstOrDefault(b => b.Class_ID == classsett.Class_ID);
            userContent.Course.Update(a);
            userContent.SaveChanges();
        }

        public JsonResult Getclass(int id)
        {
            var a = userContent.Course.FirstOrDefault(b => b.Class_ID == id);
            return Json(a);
        }

        public void deleteTest(int id)
        {
            var a = userContent.Test.FirstOrDefault(b => b.Test_ID == id);
            userContent.Test.Remove(a);
            userContent.SaveChanges();
        }
    }
}