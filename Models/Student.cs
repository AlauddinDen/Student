﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EV.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime Dob { get; set; }
        public string MobileNo { get; set; }
        public bool IsEnrolled { get; set; }
        public string ImageUrl { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<CourseModule> Modules { get; set; }
    }



    public class Course 
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<Student> Students { get; set; }

    }
    public class CourseModule 
    {
        public int CourseModuleId { get; set; }
        public string ModuleName { get; set; }
        public int Duration { get; set; }
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}