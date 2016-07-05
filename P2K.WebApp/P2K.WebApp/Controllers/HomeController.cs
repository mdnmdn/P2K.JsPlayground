using P2K.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P2K.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // test connection
            using (var ctx = new NorthwindDataContext())
            {
                ViewBag.Categories = ctx.Categories.Count();
            }
            return View();
        }

     
    }
}