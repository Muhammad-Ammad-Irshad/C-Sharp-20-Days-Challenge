using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11
{
    public class Transaction
    {
        public string Description { get; set; }
        public decimal Amount {  get; set; }
        public DateTime Date {  get; set; }
        public Transaction(string description, decimal amount)
        {
            Description = description;
            Amount = amount;
            Date = DateTime.Now;
        }
        public virtual string GetInfo()
        {
            return $"{Date.ToShortDateString()} - {Description}: {Amount:C}";
        }
    }
    public class Income : Transaction
    {
        public Income(string description, decimal amount) : base (description, amount)
        {

        }
    }
    public class Expense : Transaction
    {
        public Expense(string description, decimal amount) : base(description, amount)
        {
        }
    }
    public class ExpenseTracker
    {
        private List<Income> incomes = new List<Income>();
        private List<Expense> expenses = new List<Expense>();

        public void AddIncome(string description, decimal amount)
        {
            incomes.Add(new Income(description, amount));
            Console.WriteLine("Income added successfully.\n");
        }
        public void AddExpense(string description, decimal amount)
        {
            expenses.Add(new Expense(description, amount));
            Console.WriteLine("Expense added successfully.\n");
        }
        public void ShowSummary()
        {
            decimal totalIncome = 0;
            decimal totalExpense = 0;

            Console.WriteLine("\n---Income---");
            foreach(var income in incomes)
            {
                Console.WriteLine(income.GetInfo());
                totalIncome += income.Amount;
            }
            Console.WriteLine("\n---Expenses---");
            foreach (var expense in expenses)
            {
                Console.WriteLine(expense.GetInfo());
                totalExpense += expense.Amount;
            }
            decimal balance = totalIncome - totalExpense;

            Console.WriteLine("\n---Summary---");
            Console.WriteLine($"Total Income: {totalIncome:C}");
            Console.WriteLine($"Total Expenses: {totalExpense:C}");
            Console.WriteLine($"Balance: {balance:C}\n");
        }
    }
    internal class Expense_Tracker_App
    {
        static void Main(string[] args)
        {
            ExpenseTracker tracker = new ExpenseTracker();
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("---Expense Tracker---");
                Console.WriteLine("1. Add Income");
                Console.WriteLine("2. Add Expense");
                Console.WriteLine("3. Show Summary");
                Console.WriteLine("4. Exit");
                Console.Write("select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Enter income description: ");
                        string incDesc = Console.ReadLine();
                        Console.Write("Enter Income amount: ");
                        decimal incAmt = decimal.Parse(Console.ReadLine());
                        tracker.AddIncome(incDesc, incAmt);
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Enter expense description: ");
                        string expDesc = Console.ReadLine();
                        Console.Write("Enter expense amount: ");
                        decimal expAmt = decimal.Parse(Console.ReadLine());
                        tracker.AddExpense(expDesc, expAmt);
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        tracker.ShowSummary();
                        Console.ReadKey();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.Try Again.\n");
                        break;
                }
            }
            Console.WriteLine("Thanks for using the Expense Tracker");
        }
    }
}
