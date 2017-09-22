using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class BookRepository
    {
        public static Book [] GetBooks()
        {
            return new Book[] {
                  new Book { Title = "Pro Asp.Net MVC", Price = 890, Author = "Adam Freeman" },
                  new Book { Title = "C# Complete Reference", Price = 590, Author = "Herebert Schildt"},
                  new Book { Title = "Entity Framework", Price = 670, Author ="Julia Leeman"},
                  new Book { Title = "Asp.Net Mvc", Price = 570, Author ="Scott Guthrie"},
                  new Book { Title = "Angular", Price = 450, Author ="Tim Lee"}
            };
        }
    }
}