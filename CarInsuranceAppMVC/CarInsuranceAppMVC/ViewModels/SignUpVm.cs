using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsuranceAppMVC.ViewModels
{
    public class SignUpVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public double EstimatedQuote { get; set; }
    }
}