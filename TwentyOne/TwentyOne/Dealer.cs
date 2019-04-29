using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
  public class Dealer
    {
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }

        public void Deal(List<Card> Hand) // adding a card to the hand thats passed in and writting to the console what card is added to the hand
        {
            Hand.Add(Deck.Cards.First()); //grab the first hard
            Console.WriteLine(Deck.Cards.First().ToString() + "\n"); // add to the hand that is passed into Deal
            Deck.Cards.RemoveAt(0); 
        }
    }
}
