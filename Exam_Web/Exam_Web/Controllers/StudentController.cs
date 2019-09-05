using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Exam_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Web.Controllers
{
    public class StudentController : Controller
    {
        public  UserContent userContent;
        private IHostingEnvironment hostingEnv;
        public StudentController(UserContent _userContent, IHostingEnvironment _hostingEnv)
        {
            userContent = _userContent;
            hostingEnv = _hostingEnv;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Setting()
        {
            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.img = HttpContext.Session.GetString("img");
            var userid= HttpContext.Session.GetString("Login");          
            var studentinfo= userContent.Students.Where(b => b.student_id == userid).FirstOrDefault();
            ViewBag.info = studentinfo;
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Setting(Students student)
        {

            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.img = HttpContext.Session.GetString("img");
            var t = userContent.Students.FirstOrDefault(b => b.student_id == student.student_id);
            if (student.imgfile != null)
            {
                IFormFile file = student.imgfile;
                var fileName = file.FileName;
                var filetype = Path.GetExtension(fileName);
                var bbb = Path.GetFileNameWithoutExtension(fileName);
                //   fileName = bbb + filetype;
                fileName = hostingEnv.WebRootPath + "\\image" + $@"\{fileName}";
                var fileName1 = "/image" + $@"/{bbb}" + filetype;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                t.student_img = fileName1;
                HttpContext.Session.SetString("img", fileName1);
            }
            var dec = Request.Form["Dec"];
            t.student_name = student.student_name;
            t.student_email = student.student_email;
            t.student_dec = dec;
            userContent.SaveChanges();
            ViewBag.info = t;
            return View();
        }



        public IActionResult FindTest()
        {
            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.img = HttpContext.Session.GetString("img");
            List<Test> test = new List<Test>();
            List<string> name = new List<string>();
            var id= HttpContext.Session.GetString("Login");
            try
            {            
                test = userContent.Test.ToList();
                
                foreach (var i in test)
                {
                    var a = "";
                    try
                    {  a= userContent.Teachers.FirstOrDefault(b => b.Teacher_id == i.Tea_id).Teacher_name; }
                    catch { }
                    name.Add(a);
                }
                
            }
            catch { }
            ViewBag.teachername = name;
            ViewBag.test = test;
            return View();
        }

        public IActionResult StartTest(int id=5)
        {
            // List<Test> test = new List<Test>();
            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.img = HttpContext.Session.GetString("img");
            Test test = userContent.Test.FirstOrDefault(b=>b.Test_ID==id);
            var select = test.Test_Select.Split(",");
            var answertest = test.Test_Answer.Split(",");
            List<SelectQuestions> questions_select = new List<SelectQuestions>();
            List<AnswerQuestion> answerQuestions = new List<AnswerQuestion>();
            for(var i=0;i<select.Length;i++)
            {
                var a= userContent.SelectQuestions.FirstOrDefault(b => b.Que_ID ==int.Parse(select[i]));
                questions_select.Add(a);
            }
            for (var i = 0; i < answertest.Length; i++)
            {
                var a = userContent.AnswerQuestion.FirstOrDefault(b => b.AQ_ID == int.Parse(answertest[i]));
                answerQuestions.Add(a);
            }
            ViewBag.select = questions_select;
            ViewBag.answer = answerQuestions;
            ViewBag.test = test;
            return View();
        }

        [HttpPost]
        public IActionResult StartTest()
        {
            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.img = HttpContext.Session.GetString("img");
            var mark = 0;
            var id_s = Request.Form["T_id"];
            int id = int.Parse(id_s);
            var d = userContent.Test.FirstOrDefault(b => b.Test_ID == id);
            string select_id = d.Test_Select;
            var select = select_id.Split(",");
            var ans = d.Test_Answer.Split(",");
            Answer answer = new Answer();
            List<string> S_answer = new List<string>();
            List<string> A_answer = new List<string>();
            for (var i=0;i<select.Length;i++)
            {
                var s = Request.Form[select[i]].ToString();
                if(s!="")
                {
                    S_answer.Add(s);
                    var a = userContent.SelectQuestions.FirstOrDefault(b => b.Que_ID == int.Parse(select[i]));
                    if (s==a.Answer)
                    {
                        mark += a.Que_mark;
                    }
                }
            }
            for(var i=0;i<ans.Length;i++)
            {
                var a = Request.Form[ans[i]].ToString();
                A_answer.Add(a);
            }
            Grade grade = new Grade();
            grade.S_mark = mark;
            grade.Stu_id = HttpContext.Session.GetString("Login");
            grade.Test_id = id;
            grade.T_id = d.Tea_id;
            grade.mark = mark;
            answer.Stu_ID= HttpContext.Session.GetString("Login");
            answer.Test_ID = d.Test_ID;
            answer.S_an = string.Join(",", S_answer.ToArray());
            answer.A_an = string.Join(",", A_answer.ToArray());            
            //    grade.Stu_id == int.Parse();           
            userContent.Answer.Add(answer);
            userContent.SaveChanges();
            var ans1= userContent.Answer.FirstOrDefault(b => b.A_an ==answer.A_an);
            grade.Answer_id = ans1.A_ID;
            userContent.Grades.Add(grade);
            userContent.SaveChanges();
            var a1 = userContent.Grades.FirstOrDefault(b => b == grade);
            var new1 = userContent.Answer.FirstOrDefault(b => b.A_ID == answer.A_ID);
            new1.grade_id = a1.Gra_id;
            userContent.Answer.Update(new1);
            userContent.SaveChanges();
            return Redirect("~/Student/EndTest?Test_id=" + id_s);
        }

        public IActionResult Achievement()
        {
            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.img = HttpContext.Session.GetString("img");
            var userid = HttpContext.Session.GetString("Login");
            try
            { 
            List<Grade> Test =userContent.Grades.Where(b=>b.Stu_id.Equals(userid)).ToList();
            List<Test> tests = new List<Test>();
            foreach (var t in Test)
            {
               var a = userContent.Test.FirstOrDefault(b => b.Test_ID == t.Test_id);                
               if (a==null)

                    {
                  //      a = userContent.Test.FirstOrDefault(b => b.Test_ID == 29);
                   }
                tests.Add(a);
            }
            ViewBag.Test = Test;
            ViewBag.Test1 = tests;
            }
            catch
            {
                Console.WriteLine("erroe!");
            }
            return View();
        }

        public IActionResult EndTest(int Test_id)
        {
            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.img = HttpContext.Session.GetString("img");
            try
            {
                var Test = userContent.Test.FirstOrDefault(b => b.Test_ID == Test_id);
                var userid = HttpContext.Session.GetString("Login");
                //    var Answer = userContent.Answer.FirstOrDefault(b => b.Test_ID == Test_id && b.Stu_ID == userid);
                var grade = userContent.Grades.FirstOrDefault(b => b.Test_id == Test_id && b.Stu_id == userid);
                ViewBag.Test = Test;
                ViewBag.grade = grade;
            }
            catch { Console.WriteLine("erroe"); }
            return View();
        }

        public IActionResult AnswerTest(int Test_id)
        {
            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.img = HttpContext.Session.GetString("img");
            var userid= HttpContext.Session.GetString("Login");
            var test = userContent.Test.SingleOrDefault(b => b.Test_ID == Test_id);
            var Answer = userContent.Answer.FirstOrDefault(b => b.Test_ID==Test_id && b.Stu_ID==userid);
            var select = test.Test_Select.Split(",");
            var Answer_select = Answer.S_an.Split(",");
            List<SelectQuestions> questions_select = new List<SelectQuestions>();
            List<string> A_Sel = new List<string>();
            for (var i = 0; i < select.Length; i++)
            {
                var a = userContent.SelectQuestions.FirstOrDefault(b => b.Que_ID == int.Parse(select[i]));
                questions_select.Add(a);
                A_Sel.Add(Answer_select[i]);

            }
            ViewBag.Test = test;
            ViewBag.SelectQuestions = questions_select;
            ViewBag.Answer_Select = A_Sel;

            return View();
        }
    }
}