using CarInsuranceAppMVC.Models;
using CarInsuranceAppMVC.ViewModels;
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
            string FirstName = getquoteModel.FirstName;
            string LastName = getquoteModel.LastName;
            string EmailAddress = getquoteModel.EmailAddress;
            int CarYear = getquoteModel.CarYear;
            string CarModel = getquoteModel.CarModel.ToLower();
            string CarMake = getquoteModel.CarMake.ToLower();
            int Ticket = getquoteModel.Ticket;
            string Dui = getquoteModel.Dui;
            string Coverage = getquoteModel.Coverage;

            // code to return running value based on user input 
            DateTime Birthday = getquoteModel.Birthday;

            DateTime now = DateTime.Today;
            int age = now.Year - Birthday.Year;
            if (now < Birthday.AddYears(age)) age--;

            //age constaint
            var EstimatedQuote = getquoteModel.Age(age);
            //car make model year
            EstimatedQuote = getquoteModel.Car(EstimatedQuote, CarYear, CarMake, CarModel);
            // speeding tickets
            EstimatedQuote = getquoteModel.Tickets(EstimatedQuote, Ticket);
            //dui information 
            EstimatedQuote = getquoteModel.YesDui(EstimatedQuote, Dui);



            //    EstimatedQuote = getquoteModel.YesCoverage(EstimatedQuote, Coverage);

            //using (CarInsuranceEntities1 db = new CarInsuranceEntities1())
            //{
            //    var signup = new SignUp();
            //    signup.FirstName = getquoteModel.FirstName;
            //    signup.LastName = getquoteModel.LastName;
            //    signup.EmailAddress = getquoteModel.EmailAddress;
            //    signup.Birthday = getquoteModel.Birthday;
            //    signup.CarYear = getquoteModel.CarYear;
            //    signup.CarMake = getquoteModel.CarMake;
            //    signup.CarModel = getquoteModel.CarModel;
            //    signup.Dui = getquoteModel.Dui;
            //    //signup.Ticket = getquoteModel.Ticket;
            //    signup.Coverage = getquoteModel.Coverage;
            //    signup.EstimatedQuote = Convert.ToInt32(getquoteModel.EstimatedQuote); //REDO 

            //    db.SignUps.Add(signup);

            //    db.SaveChanges();
            //}

            //var quoteVms = new List<GetQuoteVm>
            //    {
            //        new GetQuoteVm {EstimatedQuote = EstimatedQuote}
            //    };

            return null;
            

        }


    }
}
