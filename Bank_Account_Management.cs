using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8
{
    internal class Bank_Account_Management
    {
        static void Main(string[] args)
        {
            Account myAccount = new Account("Ammad", 1000);
            bool running = true;
            

            while(running)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Bank ");
                Console.WriteLine("\n1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. View Balance");
                Console.WriteLine("4. View Transactions");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Enter amount to deposit: ");
                        double depositAmount = Convert.ToDouble(Console.ReadLine());
                        myAccount.Deposit(depositAmount);
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Enter amount to withdraw: ");
                        double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                        myAccount.Withdraw(withdrawAmount);
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine($"Current Balance: {myAccount.Balance}");
                        Console.WriteLine("Press Enter to go back.");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        myAccount.ViewTransactions();
                        Console.WriteLine("Press Enter to go back.");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Thank you for visiting. Have a nice day.");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
        class Account
        {
            private string Owner;
            private double balance;
            private List<Transaction> transactions;
            public Account(string owner, double initialBalance)
            {
                Owner = owner;
                balance = initialBalance;
                transactions = new List<Transaction>();
            }
            public double Balance
            {
                get
                {
                    return balance;
                }
            }
            public void Deposit(double amount)
            {
                if(amount <= 0)
                {
                    Console.WriteLine("Deposit amount must be positive.");
                    return;
                }
                balance += amount;
                transactions.Add(new Transaction("Depsoit", amount));
                Console.WriteLine($"Depsoited: {amount}. New Balance: {balance}");
            }
            public void Withdraw(double amount)
            {
                if(amount <= 0)
                {
                    Console.WriteLine("Withdrawal amount must be positive.");
                    return;
                }
                if(amount > balance)
                {
                    Console.WriteLine("Insufficient balance.");
                    return;
                }
                balance -= amount;
                transactions.Add(new Transaction("Withdraw", amount));
                Console.WriteLine($"Withdrawal: {amount}. New Balance: {balance}");
            }
            public void ViewTransactions()
            {
                Console.WriteLine("\n---Transaction History---");
                if(transactions.Count == 0)
                {
                    Console.WriteLine("No transactions yet.");
                    return;
                }
                foreach (var t in transactions)
                {
                    Console.WriteLine($"{t.Date}: {t.Type} of {t.Amount}");
                }
            }
        }
        class Transaction
        {
            public string Type;
            public double Amount;
            public DateTime Date;
            public Transaction(string type, double amount)
            {
                Type = type;
                Amount = amount;
                Date = DateTime.Now;
            }
        }
    }
}
