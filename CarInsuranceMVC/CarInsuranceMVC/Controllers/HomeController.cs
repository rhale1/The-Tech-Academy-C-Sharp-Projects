using CarInsuranceMVC.Models;
using CarInsuranceMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
     public ActionResult GetQuote(GetQuoteModel getquoteModel)
        {
            string FirstName = getquoteModel.FirstName;
            string LastName = getquoteModel.LastName;
            string EmailAddress = getquoteModel.EmailAddress;
            int CarYear = getquoteModel.CarYear;
            string CarModel = getquoteModel.CarModel.ToLower();
            string CarMake = getquoteModel.CarMake.ToLower();
            int Ticket = getquoteModel.Ticket;
            string Dui = getquoteModel.Dui;
            string Coverage = getquoteModel.Coverage;
         
            // return estimated quote based on user input  
            DateTime Birthday = getquoteModel.Birthday;
            DateTime now = DateTime.Today;
            int age = now.Year - Birthday.Year;
            if (now < Birthday.AddYears(age)) age--;
            //age method  update EstimatedQuote
            var EstimatedQuote = getquoteModel.Age(age);
            //car method, make model year  update EstimatedQuote
            EstimatedQuote = getquoteModel.Car(EstimatedQuote, CarYear, CarMake, CarModel);
            // speeding tickets method  update EstimatedQuote
            EstimatedQuote = getquoteModel.Tickets(EstimatedQuote, Ticket);
            //dui method update EstimatedQuote
            EstimatedQuote = getquoteModel.YesDui(EstimatedQuote, Dui);


            //connect to db
            using (CarInsurance1Entities db = new CarInsurance1Entities()) 
            {

                var user = new User();
                //pass to db from values passed to model from user
                user.FirstName = FirstName;
                user.LastName = LastName;
                user.EmailAddress = EmailAddress;
                user.Birthday = Birthday;
                user.CarYear = CarYear;
                user.CarMake = CarMake;
                user.CarModel = CarModel;
                user.Dui = Dui;
                user.Ticket = Ticket;
                user.Coverage = Coverage;
                user.EstimatedQuote = Convert.ToInt32(EstimatedQuote);
                db.Users.Add(user);
                db.SaveChanges();
            }

            var getquoteVms = new List<GetQuoteVm>
                {
                    new GetQuoteVm {EstimatedQuote = EstimatedQuote}
                };
            return View(getquoteVms);  
        }
        
    }
}