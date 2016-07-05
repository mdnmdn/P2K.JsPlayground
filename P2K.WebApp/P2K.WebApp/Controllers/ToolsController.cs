using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P2K.WebApp.Controllers
{
    public class ToolsController : Controller
    {
        // GET: Tools
        public ActionResult Now()
        {
            return Content(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }

        public ActionResult Tomorrow()
        {
            return Content(DateTime.Now.AddDays(1).ToString("dd/MM/yyyy HH:mm:ss"));
        }

        public ActionResult Random(int id = Int32.MaxValue)
        {
            var result = new { random = new Random().Next(id)};
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Guid()
        {
            var result = new { guid = System.Guid.NewGuid() };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEcho()
        {
            var result = new Dictionary<string,object>();
            foreach (string val in Request.QueryString.Keys) {
                result[val] = Request.QueryString[val];
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult PostEcho()
        {
            if (Request.HttpMethod.Equals("get", StringComparison.CurrentCultureIgnoreCase)) {
                return Content("requires a POST action");
            }

            var result = new Dictionary<string, object>();
            foreach (string val in Request.Form.Keys)
            {
                result[val] = Request.Form[val];
            }

            return Json(result);
        }
    }
}