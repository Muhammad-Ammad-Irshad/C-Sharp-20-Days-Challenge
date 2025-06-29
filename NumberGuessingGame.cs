using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2
{
    internal class NumberGuessingGame
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----Welcome to the Number Guessing Game-----");
            bool playAgain = true;
            while (playAgain)
            {
                PlayGame();
                Console.Write("Do you want to Play again?(yes/no): ");
                String response = Console.ReadLine().ToLower();

                if(response != "yes" && response != "y")
                {
                    playAgain = false;
                    Console.WriteLine("Thanks for playing! Goodbye!");
                }
            }
        }
        static void PlayGame()
        {
            Random rand = new Random();
            int secretNumber = rand.Next(1, 100);
            int guess;
            int attempts = 0;
            Console.WriteLine("\nI have selected a number between 1 and 100.");
            Console.WriteLine("Try to guess it!");

            do
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();
                if(!int.TryParse(input, out guess))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }
                attempts++;

                if(guess < secretNumber)
                {
                    Console.WriteLine("Too low! Try Again.");
                }
                else if(guess > secretNumber)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You guessed the number in {attempts} attempts.\n");
                }
            }while(guess != secretNumber);
        }
    }
}
