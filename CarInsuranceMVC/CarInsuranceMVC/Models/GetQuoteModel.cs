using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarInsuranceMVC.Models
{
    public class GetQuoteModel
    {
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter student name")]
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime Birthday { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string Dui { get; set; }
        public int Ticket { get; set; }
        public string Coverage { get; set; }

        public double EstimatedQuote = 50.0;
        // returns new insurance quote based on user age 
        public double Age(int age)
        {
            if (age <= 25 && age >= 18 || age > 100) return EstimatedQuote +=  25;
            else if (age < 18) return EstimatedQuote += 100;
            else return EstimatedQuote;
        }
        // returns new insurance quote based on car year, make and model 
        public double Car(double EstimatedQuote, int CarYear, string CarMake, string CarModel)
        {
            EstimatedQuote = CarYear < 2000 || CarYear > 2015 ? EstimatedQuote += 25 : EstimatedQuote;
            if (CarMake == "porsche" && CarModel == "911 carrera") return EstimatedQuote + 50;
            else if (CarMake == "porsche") return EstimatedQuote + 25;
            else return EstimatedQuote;
        }
        // returns new insurance quote based on # of tickets
        public double Tickets(double EstimatedQuote, int Ticket)
        {
            return Ticket == 0 ? EstimatedQuote : EstimatedQuote += Ticket * 10;
        }
        // returns new insurance quote based on what checked in dui
        public double YesDui(double EstimatedQuote, string Dui)
        {
            return Dui == "yes" ? EstimatedQuote *= 1.25 : EstimatedQuote;
        }
        // returns new insurance quote based on what is checked in coverage
        public double YesCoverage(double EstimatedQuote, string Coverage)
        {
            return Coverage == "Full Coverage" ? EstimatedQuote *= 1.50 : EstimatedQuote;
        }
    }
}
    
    
