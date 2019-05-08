using CarInsuranceAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CarInsuranceAppMVC.Controllers
{
    public class HomeController : Controller

    { 
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost] // post carries changes
        public ActionResult GetQuote(GetQuoteModel getquoteModel) //method on controller, what parameters are we sending 
        {

          
           
            return null;

        }


    }
}