using P2K.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace P2K.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            using(var ctx = new NorthwindDataContext()){

                var model = ctx.Customers.ToList();

                return View(model);
            }
        }
    }
}