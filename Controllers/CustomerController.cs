using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            Customer cust = new Customer();
            return View();
        }
        [HttpPost]
        public ActionResult Add(Customer cust)
        {
            if (cust.Age < 18)
                ModelState.AddModelError("Age", "Age must be greater than 18");

            if (ModelState.IsValid)
            {
                ViewBag.Message = "Customer Has Been Added Successfully!";
            }
            return View(cust);  // Go back to same view

            


        }
    }
}