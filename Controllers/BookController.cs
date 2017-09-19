using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            Book b = new Book { Title = "Pro Asp.Net MVC", Price = 760, Author = "Adams" };
            b.Chapters = new String[] { "Razor", "Validation", "Ajax", "Web API" };

            b.Price = b.Price > 500 ? b.Price * 1.15 : b.Price * 1.10;

            return View(b);
        }

        public ActionResult List()
        {
            Book[] books =
            {
                 new Book { Title = "Pro Asp.Net MVC", Price = 760, Author = "Adams" },
                 new Book { Title = "Angular", Price = 450, Author = "Liberty" },
                 new Book { Title = "Entity Framework", Price = 600, Author = "Leeman" }
            };

            return View(books);
        }

        public ActionResult Add()
        {
            Book b = new Book();
            return View(b);
        }

        [HttpPost]
        public ActionResult Add(Book book)
        {
            // Add book to Respository 
            return View("Added",book);
        }

    }
}