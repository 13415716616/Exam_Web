using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Web.Models
{
    public class UserContent:DbContext
    {
        public UserContent(DbContextOptions<UserContent> options):base(options)
        {

        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<SelectQuestions> SelectQuestions { get; set; }
        public DbSet<AnswerQuestion> AnswerQuestion { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Answer> Answer { get; set; }
    }
}
