using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P2K.WebApp.Controllers
{
    public class GuessNumberController : Controller
    {
        static int? _number;
        static int _trials;

        public GuessNumberController() {
            if (!_number.HasValue) GenerateNumber();
        }

        private void GenerateNumber()
        {
            _trials = 0;
            _number = new Random().Next(100);
        }

        [HttpPost]
        public ActionResult Reset()
        {
            GenerateNumber();
            return Json(new { 
                trials = _trials,
                status = "ok" 
            });
        }

        [HttpPost]
        public ActionResult Guess(int number)
        {
            if (number == _number) {
                var result = new { 
                    trials = _trials,
                    status = "ok",
                    number = _number 
                };

                GenerateNumber();

                return Json(result);
            }


            _trials++;
            var direction = _number > number ? "greater" : "smaller";

            return Json(new
            {
                trials = _trials,
                status = direction,
                message = "The misterious number is " + direction + " than " + number
            });
        }

        public ActionResult Trials()
        {
            return Json(new { trials= _trials },JsonRequestBehavior.AllowGet);
        }


    }
}