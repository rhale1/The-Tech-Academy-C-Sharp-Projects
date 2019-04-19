﻿using System;
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
            deck = Shuffle(deck, out timesShuffled, 3); // named parameter 

  
            foreach (Card card in deck.Cards)
                {
                Console.WriteLine(card.Face + " of " + card.Suit);
                }
            Console.WriteLine(deck.Cards.Count);
            Console.WriteLine("Times shuffled {0}", timesShuffled);
            Console.ReadLine();  
        }
        public static Deck Shuffle(Deck deck, out int timesShuffled, int times = 1) //static because don't want to create a object program before calling, takes a deck and returns a deck
        {
            timesShuffled = 0;
            for (int i = 0; i < times; i++)
            {
                timesShuffled++;
                List<Card> TempList = new List<Card>();// creating a temp list of cards
                Random random = new Random();

                while (deck.Cards.Count > 0)
                {
                    int randomIndex = random.Next(0, deck.Cards.Count); //create a random index between 0 and 52
                    TempList.Add(deck.Cards[randomIndex]); // then add to temp list
                    deck.Cards.RemoveAt(randomIndex);// now deleted from the list of cards
                }

                deck.Cards = TempList;
            }
            return deck;
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
