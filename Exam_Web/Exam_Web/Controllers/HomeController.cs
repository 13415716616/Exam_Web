using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Exam_Web.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace Exam_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserContent userContent;
        public HomeController(UserContent _userContent)
        {
            userContent = _userContent;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Students students)
        {
            string userid = Request.Form["userid"];
            string password = Request.Form["password"];
            try
            {
                var rode = Request.Form["rode"];
                if (rode.Equals("学生"))
                 {
                    
                    var info = userContent.Students.FirstOrDefault(b => b.student_id == userid);
                    var a = HttpContext.Session.GetString("Login");
                    var claims = new[] { new Claim("username", info.student_name)};
                    var claimsidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal user_cookie = new ClaimsPrincipal(claimsidentity);
                    Task.Run(async () =>
                    {
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user_cookie);
                    }).Wait();
                    if (info != null)
                    {
                        HttpContext.Session.SetString("Login", userid);
                        HttpContext.Session.SetString("name", info.student_name);
                        if (info.student_img == null)
                            HttpContext.Session.SetString("img", "~/image/default.jpg");
                        else
                            HttpContext.Session.SetString("img", info.student_img);
                        return RedirectToAction("FindTest", "Student");
                    }
                 }
                if(rode.Equals("教师"))
                { 
                var info_teacher = userContent.Teachers.FirstOrDefault(b => b.Teacher_id ==userid);
                if(info_teacher!=null)
                {
                    HttpContext.Session.SetString("Login", userid);
                    HttpContext.Session.SetString("name", info_teacher.Teacher_name);
                    var a = HttpContext.Session.GetString("Login");
                    var claims=new[] {new Claim("username",info_teacher.Teacher_name)};
                    var claimsidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal user_cookie = new ClaimsPrincipal(claimsidentity);
                    Task.Run(async () =>
                    {
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user_cookie);
                    }).Wait();
                    if (info_teacher.Teacher_img == null)
                        HttpContext.Session.SetString("img", "/image/default.jpg");
                    else
                        HttpContext.Session.SetString("img", info_teacher.Teacher_img);
                    return RedirectToAction("ClassSetting","Teacher");
                  //  return View("~/Teacher/ClassSetting");
                }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                ViewBag.error = "用户名或信息不匹配，请重新输入";
                return View();
            }
           ViewBag.error = "用户名或信息不匹配，请重新输入";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Students student,Teachers teachers)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            string id = Request.Form["userid"];
            string name = Request.Form["username"];
            string password = Request.Form["password"];
            string rode = Request.Form["rode"];
            if(rode.Equals("学生"))
            {
                student.student_id = id;
                student.student_name = name;
                student.student_password = password;
                student.student_time = DateTime.Now;
                userContent.Students.Add(student);
                userContent.SaveChanges();
                RedirectToAction("Home", "Login");
            }
            else if(rode.Equals("教师"))
            {
                teachers.Teacher_id = id;
                teachers.Teacher_name = name;
                teachers.Teacher_password = password;
                teachers.Teacher_time = DateTime.Now;
                userContent.Teachers.Add(teachers);
                userContent.SaveChanges();
                RedirectToAction("Home", "Login");
            }
            return View();
        }

        public void Lgout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Redirect("/Home/Login");
            HttpContext.Session.Clear();
        }

    }
}
