using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
  public  class FraudException : Exception // public class and inherits from exception, example of polymorphism
    {
        //reason creating this is to catch this specic exception
        public FraudException()
            :base() { } // inheriting from the base exception
        public FraudException(string message) //overloading construtor 

            : base(message) { } 
        

    }
}
