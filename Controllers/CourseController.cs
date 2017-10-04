using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class CourseController : Controller
    {

        public ActionResult Index()
        {
            STContext ctx = new STContext();
            var courses = ctx.Courses.ToList();
            ViewBag.Title = "List Of Courses";
            return View(courses);
        }

        public ActionResult Delete(int id)
        {

            STContext ctx = new STContext();
            var course = ctx.Courses.Find(id);

            if (course != null)
            {
                ctx.Courses.Remove(course);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("ErrorPage","", "Sorry! Course Id Not Found!");
            }

        }


        public ActionResult Add()
        {
            var course = new Course();
            ViewBag.Title = "Add Course";
            return View(course);
        }

        [HttpPost]
        public ActionResult Add(Course course)
        {
            if (ModelState.IsValid)
            {
                STContext ctx = new STContext();
                ctx.Courses.Add(course);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(course);
        }

        public ActionResult Edit(int id)
        {

            STContext ctx = new STContext();
            var course = ctx.Courses.Find(id);
            ViewBag.Title = "Edit Courses";

            if (course != null)
            {
                return View(course);
            }
            else
            {
                return View("ErrorPage","","Sorry! Course Id Not Found!");
            }

        }

        [HttpPost]
        public ActionResult Edit(int id, Course newCourse)
        {

            STContext ctx = new STContext();
            var course = ctx.Courses.Find(id);
            if (course != null)
            {
                course.Name = newCourse.Name;
                course.Fee = newCourse.Fee;
                course.Duration = newCourse.Duration;
                course.Prereq = newCourse.Prereq;
                ctx.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View("ErrorPage","", "Sorry! Course Id Not Found!");
            }

        }


        public ActionResult Search()
        {
            ViewBag.Title = "Search Courses";
            return View();
        }

        [HttpPost]
        public ActionResult Search(string name)
        {
            STContext ctx = new STContext();
            var courses = from c in ctx.Courses
                          where c.Name.Contains(name)
                          select c;

            return PartialView("SelectedCourses", courses.ToList());
        }
    }
}