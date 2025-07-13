using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_16
{
    class DiaryEntry
    {
        public string Date {  get; set; }
        public string Content { get; set; }
        private static readonly string directory = "DiaryEntries";
        public DiaryEntry(string date, string content)
        {
            Date = date;
            Content = content;
        }
        public void Save()
        {
            if(!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            string filePath = Path.Combine(directory, $"{Date}.txt");
            using(StreamWriter Writer = new StreamWriter(filePath, true))
            {
                Writer.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss") + "]");
                Writer.WriteLine(Content);
                Writer.WriteLine("-----------------------------------------");
            }
        }
        public static void Read(string date)
        {
            string filePath = Path.Combine(directory, $"{date}.txt");
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine("\n---Diary Entry for " + date + "---");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("No entry found for this date.");
            }
        }
        public static void ListAll()
        {
            if (Directory.Exists(directory))
            {
                string[] files = Directory.GetFiles(directory, "*.txt");
                Console.WriteLine("\nAll Diary Entries: ");
                foreach (var  file in files)
                {
                    Console.WriteLine(Path.GetFileNameWithoutExtension(file));
                }
            }
            else
            {
                Console.WriteLine("No entries found yet.");
            }
        }
    }
    internal class File_Based_Diary
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n---Diary Menu---");
                Console.WriteLine("1. Add New Entry");
                Console.WriteLine("2. View Entry by Date");
                Console.WriteLine("3. List All Entries");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Enter date (yyyy-MM-dd): ");
                        string date = Console.ReadLine();
                        Console.Write("Write your diary entry:\n> ");
                        string content = Console.ReadLine();
                        DiaryEntry entry = new DiaryEntry(date, content);
                        entry.Save();
                        Console.WriteLine("Entry saved.");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Enter date to read (yyyy-MM-dd): ");
                        string readDate = Console.ReadLine();
                        DiaryEntry.Read(readDate);
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        DiaryEntry.ListAll();
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Exiting diary...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please Choose again.");
                        break;
                }
            }
        }
    }
}
