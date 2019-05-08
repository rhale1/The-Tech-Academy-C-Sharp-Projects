using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarInsuranceAppMVC.Models
{
    public class GetQuoteModel
    {

        public string FirstName { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime Birthday { get; set; }
        public int carYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string Dui { get; set; }
        public int Ticket { get; set; }
        public string Coverage { get; set; }

        readonly double EstimatedQuote = 50;
        // returns new insurance quote based on user age 
        public double Age(int age)
        {
            if (age <= 25 && age >= 18 || age > 100)
            {
                var x = EstimatedQuote + 25;
                return x;
            }
            else if (age < 18)
            {
                var x = EstimatedQuote + 100;
                return x;
            }
            else
                return EstimatedQuote;
        }
        // returns new insurance quote based on car year, make and model 
        public double Car(double EstimatedQuote, int caryear, string carmake, string carmodel)
        {
            var x = caryear < 2000 || caryear > 2015 ? EstimatedQuote += 25 : EstimatedQuote;
            if (carmake == "porsche" && carmodel == "911 carrera") return x + 50;
            else if (carmake == "porsche") return x + 25;
            else return x;
        }
        // returns new insurance quote based on # of tickets
        public double Tickets(double EstimatedQuote, int tickets)
        {
            return tickets == 0 ? EstimatedQuote : EstimatedQuote += tickets * 10;
        }
        // returns new insurance quote based on what checked in dui
        public double YesDui(double EstimatedQuote, string dui)
        {
            return dui == "yes" ? EstimatedQuote *= 1.25 : EstimatedQuote;
        }
        // returns new insurance quote based on what is checked in coverage
        public double YesCoverage(double EstimatedQuote, string coverage)
        {
            return coverage == "Full Coverage" ? EstimatedQuote *= 1.50 : EstimatedQuote;
        }
    }
}
    