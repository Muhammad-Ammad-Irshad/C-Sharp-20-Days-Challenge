using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day_3
{
    internal class To_Do_List_Manager
    {
        static List<string> tasks = new List<string>();
        static void Main(string[] args)
        {
            bool running = true;
            while(running)
            {
                Console.Clear();
                Console.WriteLine("-----TO DO LIST MANAGER-----");
                Console.WriteLine("1. View Tasks");
                Console.WriteLine("2. Add Tasks");
                Console.WriteLine("3. Remove Tasks");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Choose an option from the 1-4: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewTasks();
                        break;
                    case "2":
                        AddTasks();
                        break;
                    case "3":
                        RemoveTasks();
                        break;
                    case "4":
                        running = false;
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        break;
                }
            }
        }
        static void ViewTasks()
        {
            Console.Clear();
            Console.WriteLine("===Your Tasks===");
            if(tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
            }
            else
            {
                for(int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{tasks[i]}");
                    
                }
                Console.ReadKey();
                return;
            }
            Console.WriteLine("\nPress any key to return to the menu");
            Console.ReadKey();
        }
        static void AddTasks()
        {
            Console.Clear();
            Console.WriteLine("Enter the task: ");
            string task = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(task))
            {
                tasks.Add(task);
                Console.WriteLine("Task added!");
            }
            else
            {
                Console.WriteLine("Invalid task. Nothing was added.");
            }
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
        }
        static void RemoveTasks()
        {
            Console.Clear();
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks to remove.");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                return;
            }
            ViewTasks();
            Console.WriteLine("\nEnter the task number to remove: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                if (index > 0 && index <= tasks.Count)
                {
                    Console.WriteLine($"Removed: {tasks[index - 1]}");
                    tasks.RemoveAt(index - 1);
                }
                else
                {
                    Console.WriteLine("Invalid task number.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
            Console.WriteLine("Press any key to return to menu.");
            Console.ReadKey();
        }
        static void Exit()
        {
            Console.WriteLine("Exiting...");
        }
        
    }
}
