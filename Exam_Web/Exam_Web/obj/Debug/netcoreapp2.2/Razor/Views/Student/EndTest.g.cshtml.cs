#pragma checksum "E:\proects\C#\Exam_Web\Exam_Web\Views\Student\EndTest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "646f4a63170b62d62b99274e03d08b71083e458b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_EndTest), @"mvc.1.0.view", @"/Views/Student/EndTest.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Student/EndTest.cshtml", typeof(AspNetCore.Views_Student_EndTest))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "E:\proects\C#\Exam_Web\Exam_Web\Views\_ViewImports.cshtml"
using Exam_Web;

#line default
#line hidden
#line 2 "E:\proects\C#\Exam_Web\Exam_Web\Views\_ViewImports.cshtml"
using Exam_Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"646f4a63170b62d62b99274e03d08b71083e458b", @"/Views/Student/EndTest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3567e3a03284080c6dbff07d9c2cca999d572f8", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_EndTest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "E:\proects\C#\Exam_Web\Exam_Web\Views\Student\EndTest.cshtml"
  
    ViewData["Title"] = "EndTest";
    Layout = "~/Views/Shared/Student_Layout.cshtml";
    var Test = ViewBag.Test as Test;
    var grade = ViewBag.grade as Grade;

#line default
#line hidden
            BeginContext(178, 424, true);
            WriteLiteral(@"

<div class=""row"">
    <div class=""col"">
        <div class=""col-lg-6 mb-4"" style=""margin-left:20%;margin-top:25px"">
            <div class=""card card-small mb-4"">
                <div class=""card-header border-bottom"">
                    <table class=""table mb-0"">
                        <tbody style=""align-content:center"">
                            <tr><td style=""width:150px;"">试卷名称：</td><td align=""center"">");
            EndContext();
            BeginContext(603, 14, false);
#line 17 "E:\proects\C#\Exam_Web\Exam_Web\Views\Student\EndTest.cshtml"
                                                                                 Write(Test.Test_name);

#line default
#line hidden
            EndContext();
            BeginContext(617, 98, true);
            WriteLiteral("</td></tr>\r\n                            <tr><td style=\"width:150px;\">试卷总分：</td><td align=\"center\">");
            EndContext();
            BeginContext(716, 9, false);
#line 18 "E:\proects\C#\Exam_Web\Exam_Web\Views\Student\EndTest.cshtml"
                                                                                 Write(Test.Mark);

#line default
#line hidden
            EndContext();
            BeginContext(725, 101, true);
            WriteLiteral("</td> </tr>\r\n                            <tr><td style=\"width:150px;\"> 选择题得分：</td><td align=\"center\">");
            EndContext();
            BeginContext(827, 12, false);
#line 19 "E:\proects\C#\Exam_Web\Exam_Web\Views\Student\EndTest.cshtml"
                                                                                   Write(grade.S_mark);

#line default
#line hidden
            EndContext();
            BeginContext(839, 101, true);
            WriteLiteral("</td> </tr>\r\n                            <tr><td style=\"width:150px;\"> 问答题总分：</td><td align=\"center\">");
            EndContext();
            BeginContext(941, 12, false);
#line 20 "E:\proects\C#\Exam_Web\Exam_Web\Views\Student\EndTest.cshtml"
                                                                                   Write(grade.A_mark);

#line default
#line hidden
            EndContext();
            BeginContext(953, 99, true);
            WriteLiteral("</td> </tr>\r\n                            <tr><td style=\"width:150px;\">你的总分：</td><td align=\"center\">");
            EndContext();
            BeginContext(1053, 10, false);
#line 21 "E:\proects\C#\Exam_Web\Exam_Web\Views\Student\EndTest.cshtml"
                                                                                 Write(grade.mark);

#line default
#line hidden
            EndContext();
            BeginContext(1063, 157, true);
            WriteLiteral("</td> </tr>\r\n\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
