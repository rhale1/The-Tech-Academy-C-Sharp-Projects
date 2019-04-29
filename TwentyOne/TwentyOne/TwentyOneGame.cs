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
            Dealer.Deck.Shuffle();

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
                foreach (Player player in Players) 
                {
                    Console.Write("{0}: ", player.Name);
                    Dealer.Deal(player.Hand); //passing in the players hand and given a card and that card then given to the console
                    if (i == 1)
                    {
                        bool blackJack = TwentyOneRules.CheckForBlackJack(player.Hand); // since this is a static method,  we have to prefance it with class name
                        if (blackJack)
                        {
                            Console.WriteLine("Blackjack! {0} wins {1}", player.Name, Bets[player]);
                            player.Balance += Convert.ToInt32((Bets[player] * 1.5 + Bets[player])); //give bet back plus the same amount if win 
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
                        foreach (KeyValuePair<Player, int> entry in Bets)
                        {
                            Dealer.Balance += entry.Value;
                        }
                        return;
                    }
                }
            }
            foreach (Player player in Players)
            {
                while (!player.Stay)
                {
                    Console.WriteLine("Your cards are: ");
                    foreach (Card card in player.Hand)
                    {
                        Console.Write("{0} ", card.ToString());
                    }
                    Console.WriteLine("\n\nHit or stay?");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "stay")
                    {
                        player.Stay = true;
                        break;
                        }
                        else if (answer == "hit")
                        {
                            Dealer.Deal(player.Hand);
                        }
                        bool busted = TwentyOneRules.IsBusted(player.Hand); // will return true or false
                        if (busted)
                        {
                            Dealer.Balance += Bets[player];
                            Console.WriteLine("{0} Busted! You lose your bet of {1}. Your balance is now {2}.", player.Name, Bets[player], player.Balance);
                            Console.WriteLine("Do you want to play again?");
                            answer = Console.ReadLine().ToLower();
                            if (answer == "yes" || answer == "yeah")
                            {
                            
                                player.isActivelyPlaying = true;
                                return; 
                            }
                            
                            else
                            {
                                player.isActivelyPlaying = false;
                            }
                        }
                    }
                }
            
            Dealer.isBusted = TwentyOneRules.IsBusted(Dealer.Hand);
            Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);
            while (!Dealer.Stay && !Dealer.isBusted)
            {
                Console.WriteLine("dealer is hitting...");
                Dealer.Deal(Dealer.Hand);
                Dealer.isBusted = TwentyOneRules.IsBusted(Dealer.Hand);
                Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand);
            }
            if (Dealer.Stay)
            {
                Console.WriteLine("Dealer is staying.");
            }
            if (Dealer.isBusted)
            {
                Console.WriteLine("Dealer Busted!");
                foreach (KeyValuePair<Player, int> entry in Bets)
                {
                    Console.WriteLine("{0} won {1}", entry.Key.Name, entry.Value);
                    Players.Where(x => x.Name == entry.Key.Name).First().Balance += (entry.Value * 2); // where produes a list and take the playesr balance and add player *2
                    Dealer.Balance -= entry.Value;

                }
                return;
            }
            foreach (Player player in Players)
            {
                bool? playerWon = TwentyOneRules.CompareHands(player.Hand, Dealer.Hand);// this basically says now this bool can have a value null
                if (playerWon == null)
                {
                    Console.WriteLine("Push! No one wins.");
                    player.Balance += Bets[player];

                }

                else if (playerWon == true)
                {
                    Console.WriteLine("{0} won {1}!", player.Name, Bets[player]);
                    player.Balance += (Bets[player] * 2);
                    Dealer.Balance -= Bets[player];
                }
                else
                {
                    Console.WriteLine("Dealer wins {0}!", Bets[player]);
                    Dealer.Balance += Bets[player];

                }

                Console.WriteLine("Play again?");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes" || answer == "yeah")
                {
                    player.isActivelyPlaying = true;
                }
                else
                {
                    player.isActivelyPlaying = false;
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
