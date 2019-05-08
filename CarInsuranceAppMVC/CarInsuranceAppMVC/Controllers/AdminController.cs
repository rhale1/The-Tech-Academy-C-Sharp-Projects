using CarInsuranceAppMVC.Models;
using CarInsuranceAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceAppMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var entites = new CarInsuranceEntities1();
            return (View(entites.SignUps.ToList()));
            //using (CarInsuranceEntities1 db = new CarInsuranceEntities1())
            //{
            //    var signups = new List<SignUpVm>();
            //    foreach (var signup in signups)
            //    {
            //        var signupVm = new SignUpVm();
            //        signupVm.FirstName = signup.FirstName; // pass to view model which is being passed to the view
            //        signupVm.LastName = signup.LastName;
            //        signupVm.EmailAddress = signup.EmailAddress;
            //        signupVm.EstimatedQuote = signup.EstimatedQuote;
            //        signups.Add(signupVm);
            //    }
            //    return View(signups);
            }

        }
    }
