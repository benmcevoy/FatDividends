using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fat.Web.Controllers
{
    public class StockController : Controller
    {
        //
        // GET: /Stock/

        //public ActionResult Index()
        //{
        

        //    return View();
        //}

        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Message = "Stock listing page";
            }
            else
            {
                ViewBag.Message = "A page for " + id;    
            }

            

            return View();
        }

    }
}
