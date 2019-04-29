using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class TwentyOneGame : Game, IWalkAway
    {
        public TwentyOneDealer Dealer { get; set; }

        public override void Play() // one hand one 21
        {
            Dealer = new TwentyOneDealer(); //instantiate a new dealer
            foreach (Player player in Players)
            {
                player.Hand = new List<Card>(); // new deck
                player.Stay = false; 
            }
            Dealer.Hand = new List<Card>(); // new deck
            Dealer.Stay = false;
            Dealer.Deck = new Deck();
            Console.WriteLine("Place your bet!");
        }

        public override void ListPlayers()
        {
            Console.WriteLine("21 Players");
            base.ListPlayers();
        }

        public void  WalkAway(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
