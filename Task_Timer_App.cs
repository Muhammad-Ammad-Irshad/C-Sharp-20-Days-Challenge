using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_13
{
    class TaskTimer
    {
        public string TaskName {  get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan GetDuration()
        {
            return EndTime - StartTime;
        }
        public void DisplayTask()
        {
            Console.WriteLine($"Task: {TaskName}");
            Console.WriteLine($"Start Time: {StartTime}");
            Console.WriteLine($"End Time: {EndTime}");
            Console.WriteLine($"Duration: {GetDuration()}\n");
        }
    }
    internal class Task_Timer_App
    {
        static void Main(string[] args)
        {
            List<TaskTimer> tasks = new List<TaskTimer>();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("----Task Timer App----");
                Console.WriteLine("1. Start New Task");
                Console.WriteLine("2. End Last Task");
                Console.WriteLine("3. View All Tasks");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Enter Task Name: ");
                        string taskName = Console.ReadLine();
                        TaskTimer newTask = new TaskTimer
                        {
                            TaskName = taskName,
                            StartTime = DateTime.Now,
                        };
                        tasks.Add(newTask);
                        Console.WriteLine("Task started!\n");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        if(tasks.Count == 0 || tasks[tasks.Count - 1].EndTime != default)
                        {
                            Console.WriteLine("No task to end or last task already ended.\n");
                        }
                        else
                        {
                            tasks[tasks.Count - 1].EndTime = DateTime.Now;
                            Console.WriteLine("Task ended!\n");
                        }
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        if(tasks.Count == 0)
                        {
                            Console.WriteLine("No tasks recorded.\n");
                        }
                        else
                        {
                            Console.WriteLine("---Tasks History---");
                            foreach (var task in tasks)
                            {
                                task.DisplayTask();
                            }
                        }
                        Console.ReadKey();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid option. Try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
