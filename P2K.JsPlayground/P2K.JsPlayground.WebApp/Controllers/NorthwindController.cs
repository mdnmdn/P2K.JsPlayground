
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P2K.JsPlayground.WebApp.Controllers
{
    public class NorthwindController : Controller
    {
        // GET: Northwind
        public ActionResult Index()
        {
            return View();
        }
    }
}