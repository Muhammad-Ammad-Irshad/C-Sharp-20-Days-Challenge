using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{
    internal class ATM_Simulation
    {
        static decimal balance = 1000.00m;
        const string correctPIN = "0000";
        static void Main(string[] args)
        {
            if (!AuthenticateUser())
            {
                Console.WriteLine("Too many incorrect attempts. Exiting..");
                return;
            }
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("-----ATM Menu-----");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Exit");

                if(int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CheckBalance();
                            break;
                        case 2:
                            Deposit();
                            break;
                        case 3:
                            Withdraw();
                            break;
                        case 4:
                            Console.WriteLine("Thank you for using our ATM.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please Try Again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.Please enter a number.");
                }
                if(choice != 4)
                {
                    Console.WriteLine("\nPress any key to return to menu..");
                    Console.ReadKey();
                }

            }while(choice != 4);
        }
        static bool AuthenticateUser()
        {
            int attempts = 0;
            while(attempts < 3)
            {
                Console.WriteLine("Enter your 4-digit PIN.");
                string inputPIN = Console.ReadLine();

                if(inputPIN == correctPIN)
                {
                    Console.WriteLine("PIN accepted. Access granted.\n");
                    return true;
                }
                else
                {
                    attempts++;
                    Console.WriteLine($"Incorect PIN. Attempts remaining: {3 - attempts}");
                }
            }
            return false;
        }
        static void CheckBalance()
        {
            Console.Clear();
            Console.WriteLine($"\nYour current balance is: Rs.{balance}");
        }
        static void Deposit()
        {
            Console.Clear();
            Console.WriteLine("\nEnter amount to deposit: Rs. ");
            if(decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Rs.{amount} deposited successfully.");
                Console.WriteLine($"Updated balance: Rs.{balance}");
            }
            else
            {
                Console.WriteLine("Invalid depost amount.");
            }
        }
        static void Withdraw()
        {
            Console.Clear();
            Console.Write("\nEnter amount to withdraw: Rs. ");
            if(decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                if(amount <= balance)
                {
                    balance -= amount;
                    Console.WriteLine($"Rs.{amount} withdrawn successfully.");
                    Console.WriteLine($"Remaining balance: Rs.{balance}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount.");
            }
            
        }
    }
}
