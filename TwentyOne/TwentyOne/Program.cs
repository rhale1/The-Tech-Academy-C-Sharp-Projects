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
            int timesShuffled = 0;
            deck.Shuffle(3);
  
            foreach (Card card in deck.Cards)
                {
                Console.WriteLine(card.Face + " of " + card.Suit);
                }
            Console.WriteLine(deck.Cards.Count);
            Console.ReadLine();  
        }
       
        //public static Deck Shuffle(Deck deck, int times) // function for when someone wants to shuffle deck more than once
        //{
        //    for (int i = 0; i <times; i++)
        //    {
        //        deck = Shuffle(deck);
        //    }
        //    return deck;
        //}
    }
}
