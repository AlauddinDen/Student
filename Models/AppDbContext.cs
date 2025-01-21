using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EV.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base("AppDbContext")
        {
            
        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseModule> Modules { get; set; }



    }
}