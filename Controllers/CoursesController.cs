using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

// RESTful Service - WEB API 

namespace mvcdemo.Controllers
{
    public class CoursesController : ApiController
    {
        public IEnumerable<Course> Get()
        {
            using (STContext ctx = new STContext())
            {
                return ctx.Courses.ToList();
            }
        }

        public IEnumerable<Course> Get(string pattern)
        {
            using (STContext ctx = new STContext())
            {
                return ctx.Courses.Where(c => c.Name.Contains(pattern)).ToList();
            }
        }

        public Course Get(int id)
        {
            using (STContext ctx = new STContext())
            {
                var course = ctx.Courses.Find(id);
                if (course == null)
                {
                    HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.NotFound);
                    throw new HttpResponseException(msg);
                }
                else
                    return course;
            }
        }

        public void Delete(int id)
        {
            using (STContext ctx = new STContext())
            {
                var course = ctx.Courses.Find(id);
                if (course == null)
                {
                    HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.NotFound);
                    throw new HttpResponseException(msg);
                }
                else
                {
                    ctx.Courses.Remove(course);
                    ctx.SaveChanges();
                }
            }

        }

        public void Post(Course course)
        {
            using (STContext ctx = new STContext())
            {
                try
                {
                    ctx.Courses.Add(course);
                    ctx.SaveChanges();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    HttpContext.Current.Trace.Write("Error : " + ex.Message);
                    HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    throw new HttpResponseException(msg);
                }
            }
        }

        
        public void Put(int id, Course newCourse)
        {

            using (STContext ctx = new STContext())
            {
                var course = ctx.Courses.Find(id);
                if (course != null)
                {
                    course.Name = newCourse.Name;
                    course.Fee = newCourse.Fee;
                    course.Duration = newCourse.Duration;
                    course.Prereq = newCourse.Prereq;
                    try
                    {
                        ctx.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                        throw new HttpResponseException(msg);
                    }
                }
                else
                {
                    HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.NotFound);
                    throw new HttpResponseException(msg);
                }

            }
        }
    }
}