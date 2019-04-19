using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck(); // now it should have an entire deck of 52 cards
            deck = Shuffle(deck); 
  
            foreach (Card card in deck.Cards)
                {
                Console.WriteLine(card.Face + " of " + card.Suit);
                }
            Console.WriteLine(deck.Cards.Count);
            Console.ReadLine();  
        }
        public static Deck Shuffle(Deck deck) //static because don't want to create a object program before calling, takes a deck and returns a deck
        {
            List<Card> TempList = new List<Card>();// creating a temp list of cards
            Random random = new Random();
             while  (deck.Cards.Count > 0)
            {
                int randomIndex = random.Next(0, deck.Cards.Count); //create a random index between 0 and 52
                TempList.Add(deck.Cards[randomIndex]); // then add to temp list
                deck.Cards.RemoveAt(randomIndex);// now deleted from the list of cards
            }
            deck.Cards = TempList;
            return deck;

        }
    }
}
