using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            int compScore = 0;
            int playerScore = 0;
            int tieScore = 0;
            int rounds;
            int input;
            int compInput;
            bool replay = true;
            Random random = new Random();
                        
            while (replay = true)
            {
                Console.WriteLine("Welcome to Rock, Paper, Scissors! You can play up to 10 rounds. How many would you like to play?");
                string strRounds = Console.ReadLine();

                //This will check if the input is an int, and is between 1-10
                if (int.TryParse(strRounds, out rounds) && rounds < 11 && rounds > 0)
                {
                    Console.WriteLine("Good job");

                }
                else
                {
                    Console.WriteLine("ERROR - Please try again - Press ENTER");
                    Console.ReadLine();

                    //This will close the application 
                    System.Environment.Exit(0);
                }
                //Now we will start the rounds
                for (int i = rounds; i > 0; i--)
                {
                    Console.WriteLine("There are " + i + " rounds left of " + rounds);
                    Console.WriteLine("Please enter Rock(1), Paper(2), or Scissors(3)");
                    string strUserInput = Console.ReadLine();
                    if (int.TryParse(strUserInput, out input) && input == 1)
                    {
                        Console.WriteLine("You chose ROCK");
                        input = 1;
                        compInput = random.Next(1, 3);
                        if (compInput == 2)
                        {
                            ++compScore;
                            Console.WriteLine("You lost to PAPER");
                        }
                        else if (compInput == 3)
                        {
                            ++playerScore;
                            Console.WriteLine("You beat SCISSORS");
                        }
                        else if (compInput == input)
                        {
                            Console.WriteLine("You tied!");
                            ++tieScore;
                        }
                    }
                    else if (int.TryParse(strUserInput, out input) && input == 2)
                    {
                        Console.WriteLine("You chose PAPER");
                        input = 2;
                        compInput = random.Next(1, 3);
                        if (compInput == 3)
                        {
                            ++compScore;
                            Console.WriteLine("You lost to SCISSORS");
                        }
                        else if (compInput == 1)
                        {
                            ++playerScore;
                            Console.WriteLine("You beat ROCK");
                        }
                        else if (compInput == input)
                        {
                            Console.WriteLine("You tied!");
                            ++tieScore;
                        }
                    }
                    else if (int.TryParse(strUserInput, out input) && input == 3)
                    {
                        Console.WriteLine("You chose SCISSORS");
                        input = 3;
                        compInput = random.Next(1, 3);
                        if (compInput == 1)
                        {
                            ++compScore;
                            Console.WriteLine("You lost to ROCK");
                        }
                        else if (compInput == 2)
                        {
                            ++playerScore;
                            Console.WriteLine("You beat PAPER");
                        }
                        else if (compInput == input)
                        {
                            Console.WriteLine("You tied!");
                            ++tieScore;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error -- You chose an incorrect choice -- Press ENTER");
                        Console.ReadLine();
                        System.Environment.Exit(0);
                    }
                }
                if (compScore > playerScore && compScore >= tieScore)
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("You LOST");
                    Console.WriteLine("You scored " + playerScore + " points!");
                    Console.WriteLine("You lost " + compScore + " rounds.");
                    Console.WriteLine("There were " + tieScore + " ties.");
                }
                else if (playerScore > compScore && playerScore >= tieScore)
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("You WON");
                    Console.WriteLine("You scored " + playerScore + " points!");
                    Console.WriteLine("You lost " + compScore + " rounds.");
                    Console.WriteLine("There were " + tieScore + " ties.");
                }
                else if (tieScore >= compScore && tieScore >= playerScore)
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("CAT'S GAME");
                    Console.WriteLine("You scored " + playerScore + " points!");
                    Console.WriteLine("You lost " + compScore + " rounds.");
                    Console.WriteLine("There were " + tieScore + " ties.");
                }
                Console.WriteLine("Would you like to replay? (Y) for Yes. (N) for no");
                string strReplay = Console.ReadLine();
                if (strReplay == "y" || strReplay == "Y")
                {
                    replay = true;
                }
                else
                {
                    System.Environment.Exit(0);
                }
            }
            //string strReplay = Console.ReadLine();
            //if (strReplay == "y" || strReplay == "Y") 
            //{
            //    replay = true;
            //}
            //else
            //{
            //    replay = false;
            //}
            ////else if (strReplay == "N" || strReplay == "n")
            ////{
            ////    replay = false;
            ////}
            //else
            //{
            //    Console.WriteLine("Invalid input, program closing.");
            //}

            Console.ReadLine();
        }
    }
}
