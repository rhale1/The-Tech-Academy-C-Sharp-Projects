using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
   public class ExceptionEntity // entitiy commonly refereed to a class that maps exactly to a db
    {
        public int Id { get; set; }
        public string ExceptinType { get; set; }
        public string ExceptionMessage { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
