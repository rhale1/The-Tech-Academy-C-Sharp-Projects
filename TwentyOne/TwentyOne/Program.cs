using System;
using Casino;
using System.IO;
using Casino.TwentyOne;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace TwentyOne
 
{
    class Program
    {
        static void Main(string[] args)
        {
            const string casinoName = "Grand Hotel and Casino";

            Console.WriteLine("Welcome to the {0}. Let's start by telling me your name.", casinoName);
            string playerName = Console.ReadLine();
            if (playerName.ToLower() == "admin")
            {
                List<ExceptionEntity> Exceptions = ReadExceptions(); // calls this method that reads all the exceptions from the db and assigns to list
                foreach (var exception in Exceptions)
                {
                    Console.Write(exception.Id + " | ");
                    Console.Write(exception.ExceptinType + " | ");
                    Console.Write(exception.ExceptionMessage + " | ");
                    Console.Write(exception.TimeStamp + " | ");
                    Console.WriteLine();
                }

                Console.Read();
                return;
            }
            bool validAnswer = false;
            int bank = 0;
            while (!validAnswer)
            {
                Console.WriteLine("And how much money did you bring today? ");
                validAnswer = int.TryParse(Console.ReadLine(), out bank); //convernts the string rep of number to its 32 bit int and return value indicates if succeeded
                if (!validAnswer) Console.WriteLine("Please enter digits only, no decimals");
            }

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
                    try
                    {
                        game.Play();
                    }
                    catch (FraudException ex) // a more specific exception
                    {
                        Console.WriteLine(ex.Message);
                        UpdateDbWithException(ex); //update database with exception details, so know if error occurs or if kick a person out
                        Console.ReadLine();
                        return;
                    }
                    catch (Exception ex) //generic exception
                    {
                        Console.WriteLine("An error occurred. Please contact your System Administrator.");
                        UpdateDbWithException(ex);
                        Console.ReadLine();
                        return;
                    }
                }
                game -= player;
                Console.WriteLine("Thank you for player!");
            }
            Console.WriteLine("Feel free to  look around the casino. Bye for now");
            Console.ReadLine();
        }
        private static void UpdateDbWithException(Exception ex) // all exceptions inherit from exception
        { //always need a connection string to connect with database

            string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=TwentyOneGame;
            Integrated Security=True;Connect Timeout=30;Encrypt=False;
            TrustServerCertificate=False;ApplicationIntent=
            ReadWrite;MultiSubnetFailover=False";
            //parameterized queries
            string queryString = @"INSERT INTO exceptions (ExceptionType, ExceptionMessage, TimeStamp) VALUES 
                                (@ExceptionType, @ExceptionMessage, @TimeStamp)"; // these are just placeholders, helps with SQL injection

            //using statements are a way of controling CLR, i.e we are dealing with external resources
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@ExceptionType", SqlDbType.VarChar); //this is the datatype inside table. by naming its datatype you are protecting against sql injection
                command.Parameters.Add("@ExceptionMessage", SqlDbType.VarChar);
                command.Parameters.Add("@TimeStamp", SqlDbType.DateTime);

                command.Parameters["@ExceptionType"].Value = ex.GetType().ToString(); // get type returns a datatype type but now convert to string.
                command.Parameters["@ExceptionMessage"].Value = ex.Message; // already a string
                command.Parameters["@TimeStamp"].Value = DateTime.Now;

                //now send to database...
                connection.Open(); // opens connects
                command.ExecuteNonQuery(); // its a nonquery becuase insert statement
                connection.Close();
            }
        }
        private static List<ExceptionEntity> ReadExceptions()
        {
            string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=TwentyOneGame;
            Integrated Security=True;Connect Timeout=30;Encrypt=False;
            TrustServerCertificate=False;ApplicationIntent=
            ReadWrite;MultiSubnetFailover=False";

            string queryString = @"Select Id, ExceptionType, ExceptionMessage, TimeStamp From Exceptions";
            List<ExceptionEntity> Exceptions = new List<ExceptionEntity>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read()) // loops through each record getting back
                {
                    ExceptionEntity exception = new ExceptionEntity();
                    exception.Id = Convert.ToInt32(reader["Id"]);
                    exception.ExceptinType = reader["ExceptionType"].ToString();
                    exception.ExceptionMessage = reader["ExceptionMessage"].ToString();
                    exception.TimeStamp = Convert.ToDateTime(reader["TimeStamp"]);
                    Exceptions.Add(exception); // was Exceptions.add(exception)

                }
                connection.Close();
            }
            return Exceptions;
        }
    }
}

