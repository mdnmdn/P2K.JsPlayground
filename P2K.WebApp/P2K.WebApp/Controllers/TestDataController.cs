using P2K.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P2K.WebApp.Controllers
{
    public class TestDataController : Controller
    {
        // GET: TestData
        public ActionResult Index(int page = 0)
        {
            List<Order> orders = LoadData();

            ViewBag.Page = page;
            ViewBag.Orders = orders;

            int pageSize = 50;

            var data = orders.Skip(page * pageSize).Take(pageSize).ToList();

            return View(data);
        }

        private List<Order> LoadData()
        {
            List<Order> orders = (List<Order>)
                HttpContext.Cache["ordini"] ;


            if (orders == null)
            {

                using (var ctx = new NorthwindDataContext())
                {
                    orders = ctx.Orders.ToList();
                    foreach (var order in orders)
                    {
                        var customer = order.Customer;
                        order.OrderDetails.ToList();
                    }
                }

                HttpContext.Cache["ordini"] = orders;
            }
            return orders;
        }
    }
}