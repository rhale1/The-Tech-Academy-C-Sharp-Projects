using System;
using Casino;
using System.IO;
using Casino.TwentyOne;
namespace TwentyOne
 
{
    class Program
    {
        static void Main(string[] args)
        {
            const string casinoName = "Grand Hotel and Casino";

            Console.WriteLine("Welcome to the {0}. Let's start by telling me your name.", casinoName);

            string playerName = Console.ReadLine();
            Console.WriteLine("And how much money did you bring today?");
            int bank = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hello, {0} Would you like to join a game of 21 right now?", playerName);
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya")
            {
                Player player = new Player(playerName, bank); //if want to play, create new player object and initalize it with name and how much brought, and instantiated
                player.Id = Guid.NewGuid(); // right now creating a guid for every player. 
                using (StreamWriter file = new StreamWriter(@"C:\Users\Student\Logs\Log.text", true))
                {
                    file.WriteLine(player.Id); //logs the guid now. 
                    
                }
                Game game = new TwentyOneGame();
                game += player;
                player.isActivelyPlaying = true;
                while (player.isActivelyPlaying && player.Balance > 0)
                {
                    game.Play();
                }
                game -= player;
                Console.WriteLine("Thank you for player!");
            }
            Console.WriteLine("Feel free to  look around the casino. Bye for now");
            Console.ReadLine();
        }
    }
}

