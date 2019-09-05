using Exam_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exam_Web.Controllers
{
    public class TeacherController : Controller
    {
        private UserContent userContent;
        private readonly IHostingEnvironment _hostingEnv;

        public TeacherController(UserContent userContent, IHostingEnvironment hostingEnv)
        {
            this.userContent = userContent;
            this._hostingEnv = hostingEnv;
        }

        //public IActionResult Index()
        //{
        //    return View();
      //  }

        [Authorize]
        public IActionResult ClassSetting()
        {
            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.img = HttpContext.Session.GetString("img");
            var a = ViewBag.name;
            List<Course> courses = new List<Course>();
            courses = userContent.Course.ToList();
            ViewBag.course = courses;
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult ClassSetting(Course  course)
        {
            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.img = HttpContext.Session.GetString("img");
            try
            { 
            userContent.Course.Add(course);
            userContent.SaveChanges();
            List<Course> courses = new List<Course>();
            courses = userContent.Course.ToList();
            ViewBag.course = courses;}
            catch { }
           // RedirectToAction("ClassSetting", "Teacher");
            return View();
        }

        [Authorize]
        public IActionResult QuestionsSetting()
        {
            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.img = HttpContext.Session.GetString("img");
            List<SelectQuestions> questions = userContent.SelectQuestions.ToList();
            List<AnswerQuestion> answers = userContent.AnswerQuestion.ToList();
            ViewBag.questions = questions;
            ViewBag.answers = answers;
            return View();
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult QuestionsSetting(SelectQuestions questions,AnswerQuestion answer)
        {
            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.img = HttpContext.Session.GetString("img");
            string search = Request.Form["Search_info"];
            if (search != null)
            {   var info = userContent.SelectQuestions.Where(b => b.Que_name.Contains(search)).ToList();
                ViewBag.questions = info;
                return View();
            }
            if (answer.AQ_Name != null)
            {
                userContent.AnswerQuestion.Add(answer);
                userContent.SaveChanges();
            }
            else if (questions.Que_name != null)
            {   userContent.SelectQuestions.Add(questions);
                userContent.SaveChanges();
            }
            //  var a = Request.Form["first"];           
            List<SelectQuestions> questions1 = userContent.SelectQuestions.ToList();
            List<AnswerQuestion> answers = userContent.AnswerQuestion.ToList();
            ViewBag.questions = questions1;
            ViewBag.answers = answers;
            return View();
        }

        [Authorize]
        public IActionResult CreateTest()
        {
            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.img = HttpContext.Session.GetString("img");
            ViewBag.All_test = userContent.Test.ToList();
            return View();
        }

        [Authorize]
        public IActionResult EditTest()
        {
            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.img = HttpContext.Session.GetString("img");
            var test = userContent.Test.ToList();
            var select = userContent.SelectQuestions.ToList();
            var answer = userContent.AnswerQuestion.ToList();
            ViewBag.select = select;
            ViewBag.answer = answer;
            return View();
        }

        [Authorize]
        public IActionResult Setting()
        {
            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.img = HttpContext.Session.GetString("img");
            var id= HttpContext.Session.GetString("Login");
            var a = HttpContext.Session.GetString("Login");
            try { 
            Teachers teachers = userContent.Teachers.FirstOrDefault(b => b.Teacher_id == id.ToString());
            ViewBag.Teacher = teachers;
            }
            catch
            {
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Setting(Teachers teachers)
        {
            ViewBag.name = HttpContext.Session.GetString("name");
            ViewBag.img = HttpContext.Session.GetString("img");        
            var t = userContent.Teachers.FirstOrDefault(b => b.Teacher_id == teachers.Teacher_id);
            if (teachers.imgfile != null)
            {
                IFormFile file = teachers.imgfile;
                var fileName = file.FileName;
                var filetype = Path.GetExtension(fileName);
                var bbb = Path.GetFileNameWithoutExtension(fileName);
             //   fileName = bbb + filetype;
                fileName = _hostingEnv.WebRootPath + "\\image" + $@"\{fileName}";
                var fileName1 = "/image" + $@"/{bbb}"+filetype;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                t.Teacher_img= fileName1;
                HttpContext.Session.SetString("img",fileName1);
            }
            var dec = Request.Form["Dec"];
            t.Teacher_name = teachers.Teacher_name;
            t.Teacher_email = teachers.Teacher_email;
            t.Teacher_dec = dec;
            userContent.SaveChanges();
            ViewBag.Teacher = t;
            return View();
        }


        //public IActionResult ModifyTest(int id)
        //{
        //    var test = userContent.Test.FirstOrDefault(b => b.Test_ID == id);
        //    List<string> select = test.Test_Select.Split(",");
        //    ViewBag.test = test;
        //    return View();
        //}

       public IActionResult Grade()
        {
            var id = HttpContext.Session.GetString("Login");
            var all = userContent.Grades.Where(b => b.T_id==id).ToList();
            List<string> username=new List<string>();
            List<string> Testname = new List<string>();
            foreach (var a in all)
            {
                var i="";var j="";
                try
                { 
                i= userContent.Students.FirstOrDefault(b => b.student_id == a.Stu_id).student_name;
                j= userContent.Test.FirstOrDefault(b => b.Test_ID == a.Test_id).Test_name; }
                 catch { }
                username.Add(i);
                Testname.Add(j);
               
               
            }
            ViewBag.username = username;
            ViewBag.Testname = Testname;
            ViewBag.grade = all;
            return View();
        }

        public IActionResult CorrectTest()
        {
            var id = HttpContext.Session.GetString("Login");
            var all = userContent.Answer.Where(b => b.A_an != null).ToList();
            List<string> name = new List<string>();
            List<int> gradeid = new List<int>();
            List<int> smark = new List<int>();
            foreach (var a in all)
            {
                try
                { 
                var j = userContent.Grades.FirstOrDefault(b => b.Gra_id == a.grade_id &&b.A_mark==0);
               if(j!=null)
                {
                    var tname = userContent.Test.FirstOrDefault(b => b.Test_ID == j.Test_id);
                    name.Add(tname.Test_name);
                    gradeid.Add(j.Gra_id);
                    smark.Add(j.S_mark);
                }
                }
                catch { }
            }
            ViewBag.name = name;
            ViewBag.gradeid = gradeid;
            ViewBag.smark = smark;
            return View();
        }
    }
}