using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class AjaxController : Controller
    {
        public ActionResult Controls()
        {
            return View();
        }

        
        public ActionResult Index()
        {
            return View();
        }

        public string Now()
        {
            return DateTime.Now.ToString();
        }

        public  ActionResult Search(string pattern)
        {
            // Thread.Sleep(3000);
            var books = BookRepository.GetBooks()
                        .Where(b => b.Title.ToUpper().Contains(pattern.ToUpper()));

            //if (books.Count() > 0)
            //    return PartialView("_books", books);
            //else
            //    return Content("<h3>Sorry! No books found!</h3>");

            return  PartialView("_books", books);

        }
    }
}