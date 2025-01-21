using EV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EV.ViewModel;
using System.IO;
namespace EV.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students

        private readonly AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            var Slist = db.Students.Include(m=>m.Modules).Include(c=>c.Course).ToList();
            return View(Slist);
        }
        public ActionResult Delete(int? id) 
        {
            var stu = db.Students.Find(id);
            var module = db.Modules.Where(m=>m.StudentId == id).ToList();
            foreach (var item in module)
            {
                db.Modules.Remove(item);
            }
            db.Entry(stu).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpGet]
        public ActionResult Create() 
        {
            StudentViewModel student = new StudentViewModel();
            student.Courses = db.Courses.ToList();
            student.Modules.Add(new CourseModule() { StudentId = 1 });
            return View(student);

        }
        [HttpPost]
        public ActionResult Create(StudentViewModel m) 
        {
            Student s = new Student();
            HttpPostedFileBase file = m.ProfileFile;
            if (file != null) 
            {
                string filePath = Path.Combine("/Img/", Guid.NewGuid().ToString() +
                    Path.GetExtension(file.FileName));
                file.SaveAs(Server.MapPath(filePath));
                m.ImageUrl = filePath;
            }
            s.ImageUrl =m.ImageUrl;
            s.StudentName = m.StudentName;
            s.Dob=m.Dob;
            s.MobileNo = m.MobileNo;
            s.IsEnrolled = m.IsEnrolled;
            s.CourseId = m.CourseId;
            s.Modules = m.Modules;
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");

        }



    }
}