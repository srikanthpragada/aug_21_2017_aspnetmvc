using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class HelloController : Controller
    {
        // Hello/Index?name=Srikanth
        // Test/Srikanth 
        public ActionResult Index(string name)
        {
            ViewBag.Name = name;
            ViewBag.Message = "Today is : " + DateTime.Now.ToLongDateString();
            ViewBag.Author = "Srikanth Pragada";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}