using EV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EV.ViewModel
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        [Required]
        [Display(Name ="Student Name")]
        public string StudentName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy-MM-dd}")]
        [Display(Name = "Date Of Birth")]
        public DateTime Dob { get; set; }= DateTime.Now;
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }
        [Display(Name = "Enrollment")]
        public bool IsEnrolled { get; set; }
        [Display(Name = "Profile Pictur")]
        public string ImageUrl { get; set; }
        public int CourseId { get; set; }
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        public int CourseModuleId { get; set; }
        public string ModuleName { get; set; }
        public int Duration { get; set; }

        public HttpPostedFileBase ProfileFile { get; set; }

        public  IList<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        public virtual IList<CourseModule> Modules { get; set; }=new List<CourseModule>();


    }
}