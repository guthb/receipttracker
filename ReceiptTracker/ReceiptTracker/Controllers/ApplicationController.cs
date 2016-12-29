using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReceiptTracker.Controllers
{
    public class ApplicationController : Controller
    {
        
            public ActionResult Index()
            {
                return View();
            }

            public ActionResult About()
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }

        }
}
