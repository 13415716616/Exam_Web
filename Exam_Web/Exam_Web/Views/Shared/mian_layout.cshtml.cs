using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exam_Web.Views.Shared
{
    public class mian_layoutModel : PageModel
    {
        public void OnGet()
        {
            ViewData["A"] = "111111111111111111111111111111111111";
        }
    }
}