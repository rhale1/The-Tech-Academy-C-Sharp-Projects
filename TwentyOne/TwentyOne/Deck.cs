using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
   public class Deck
    {
        public Deck()
        {
            Cards = new List<Card>(); // this is refering to the property of the class, why no data type or variable 
            for (int i=0; i< 13; i++) 
            {
                for (int j = 0; j < 4; j++)
                {
                    Card card = new Card();
                    card.Face = (Face)i;
                    card.Suit = (Suit)j;
                    Cards.Add(card);
                }
            }
        }
        public List<Card> Cards { get; set; } // class properties

        public void Shuffle(int times = 1) //static because don't want to create a object program before calling, takes a deck and returns a deck
        {
            for (int i = 0; i < times; i++)
            {
                List<Card> TempList = new List<Card>();// creating a temp list of cards
                Random random = new Random();

                while (Cards.Count > 0)
                {
                    int randomIndex = random.Next(0, Cards.Count); //create a random index between 0 and 52
                    TempList.Add(Cards[randomIndex]); 
                    Cards.RemoveAt(randomIndex);
                }

               Cards = TempList;
            }     
        }

    }
}
