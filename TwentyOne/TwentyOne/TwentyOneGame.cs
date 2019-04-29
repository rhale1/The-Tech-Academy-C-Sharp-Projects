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
                Bets[player] = bet; //Bets, which rep the dictionary with the player is the key, and the bet
            }
        for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Dealing...");
               foreach (Player player in Player)
                {
                    Console.Write("{0}: ", player.Name);
                    Dealer.Deal(player.Hand); //passing in the players hand and given a card and that card then given to the console
                    if (i == 1)
                    {
                        bool blackJack = TwentyOneRules.CheckForBlackJack(player.Hand); // since this is a static method,  we have to prefance it with class name
                        if (blackJack)
                        {
                            Console.WriteLine("Blackjack! {0} wins {1}", player.Name, Bets[player]);
                            player.Balance += Convert.ToInt32((Bets[player] * 1.5 + Bets[player)); //give bet back plus the same amount if win 
                            return;
                        }

                    }
                }
                Console.Write("Dealer: ");
                Dealer.Deal(Dealer.Hand); 
                if (i == 1)
                {
                    bool blackJack = TwentyOneRules.CheckForBlackJack(Dealer.Hand);
                    if (blackJack)
                    {
                        Console.WriteLine("Dealer has BlackJack! Everyone loses!");
                        foreach(KeyValuePair<Player, int> entry in Bets)
                        {
                            Dealer.Balance += entry.Value; 
                        }
                    }
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
