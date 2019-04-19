using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class Card
    {
        public Card()
        {
            Suit = "Spades";
            Face = "Two";
        }

       public string Face {get; set;}
       public string Suit {get; set;}
    }
}
