using CarInsuranceMVC.Models;
using CarInsuranceMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CarInsuranceMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetQuote(GetQuoteModel quote)
        {
            // return estimated quote based on user input  
            DateTime Birthday = quote.Birthday;
            DateTime now = DateTime.Today;
            int age = now.Year - Birthday.Year;
            if (now < Birthday.AddYears(age)) age--;
            //age method  update EstimatedQuote
            var EstimatedQuote = quote.Age(age);
            //car method, make model year; update EstimatedQuote
            EstimatedQuote = quote.Car(EstimatedQuote, quote.CarYear, quote.CarMake.ToLower(), quote.CarModel.ToLower());
            // speeding tickets method; update EstimatedQuote
            EstimatedQuote = quote.Tickets(EstimatedQuote, quote.Ticket);
            //dui method update EstimatedQuote
            EstimatedQuote = quote.YesDui(EstimatedQuote, quote.Dui);
            //coverage method update EstimatedQuote
            EstimatedQuote = quote.YesCoverage(EstimatedQuote, quote.Coverage);

            //instantiate entitiy object and pass in connection string to access to db
            using (CarInsurance1Entities db = new CarInsurance1Entities())
            {
                var user = new User
                { //pass db values passed to model from UI
                    FirstName = quote.FirstName,
                    LastName = quote.LastName,
                    EmailAddress = quote.EmailAddress,
                    Birthday = quote.Birthday,
                    CarYear = quote.CarYear,
                    CarMake = quote.CarMake,
                    CarModel = quote.CarModel,
                    Dui = quote.Dui,
                    Ticket = quote.Ticket,
                    Coverage = quote.Coverage,
                    EstimatedQuote = Convert.ToDecimal(EstimatedQuote)
                }; 
                db.Users.Add(user); // add to db        
                db.SaveChanges();  //save to db
            }
            var getquoteVms = new List<GetQuoteVm>
            {
                new GetQuoteVm {EstimatedQuote = EstimatedQuote}
            };
            return View(getquoteVms);
        }
    }
}
        
    
