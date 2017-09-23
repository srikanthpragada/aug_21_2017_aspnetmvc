using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class CacheController : Controller
    {
        [OutputCache ( Duration = 60, VaryByParam = "cat")]
        public ActionResult Index()
        {
            return View(DateTime.Now);
        }

        public Book[]  GetBooks()
        {
            var books = HttpContext.Cache["books"] as Book[];
            if (books == null)
            {
                books = BookRepository.GetBooks();
                HttpContext.Cache.Insert("books",
                     books,
                     null,
                     DateTime.Now.AddMinutes(2),
                     TimeSpan.Zero);
                ViewBag.Message = "Cache Created!";
            }
            else
                ViewBag.Message = "Cache is being used!";

            return books; 

        }

        public ActionResult List()
        {
            var books = GetBooks();
            return View(books);
        }

        public ActionResult Search(string pattern)
        {
            var books = GetBooks().Where(b => b.Title.Contains(pattern));

            return View(books);
        }



    }
}