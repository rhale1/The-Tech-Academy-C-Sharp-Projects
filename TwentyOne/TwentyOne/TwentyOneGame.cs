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

        foreach (Player player in Players)
            {
                int bet = Convert.ToInt32(Console.ReadLine());
                bool successfullyBet = player.Bet(bet); //pass in the amount they bet into the bet method
                if (!successfullyBet) // if succfully bet is false same as succesfullybet ==false
                {
                    return; // not returning anything but means end this method and goes back to while loop (play method)
                }
            }
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
