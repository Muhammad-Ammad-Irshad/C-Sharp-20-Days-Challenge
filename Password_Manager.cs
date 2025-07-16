using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_19
{
    internal class Password_Manager
    {
        private static string filePath = "password.txt";
        private static List<PasswordEntry> passwordList = new List<PasswordEntry>();
        static void Main(string[] args)
        {
            LoadPasswords();
            bool t = true;
            while (t)
            {
                Console.Clear();
                Console.WriteLine("---Password Manager---");
                Console.WriteLine("1. Add Password");
                Console.WriteLine("2. View Passwords");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        AddPassword();
                        break;
                    case "2":
                        Console.Clear();
                        ViewPasswords();
                        break;
                    case "3":
                        Console.Clear();
                        SavePasswords();
                        Console.WriteLine("Goodbye");
                        t = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        Console.WriteLine("\nPress Enter to continue...");
                        Console.ReadLine();
                        break;
                }
                
            }
        }
        static void Exit()
        {
            
        }
        static void AddPassword()
        {
            Console.Write("Enter Website: ");
            string website = Console.ReadLine();
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            var entry = new PasswordEntry(website, username, password);
            passwordList.Add(entry);
            Console.WriteLine("Password saved!");
            Console.ReadKey();
        }
        static void ViewPasswords()
        {
            if(passwordList.Count == 0)
            {
                Console.WriteLine("No passwords stored.");
                return;
            }
            Console.WriteLine("\nStored Passwords: ");
            foreach (var entry in passwordList)
            {
                Console.WriteLine(entry.ToString());
            }
            Console.ReadKey();
        }
        static void LoadPasswords()
        {
            if (!File.Exists(filePath))
                return;
            string[] lines = File.ReadAllLines(filePath);
            foreach(string line in lines)
            {
                var entry = PasswordEntry.FromFileFormat(line);
                if(entry != null)
                    passwordList.Add(entry);
            }
        }
        static void SavePasswords()
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach(var entry in passwordList)
                {
                    sw.WriteLine(entry.ToFileFormat());
                }
            }
        }
    }
    class PasswordEntry
    {
        public string Website { get; set; }
        public string Username { get; set; }
        public string EncodedPassword { get; set; }
        public PasswordEntry(string website, string username, string password)
        {
            Website = website;
            Username = username;
            EncodedPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
        }
        public string GetDecodedPassword()
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(EncodedPassword));
        }
        public override string ToString()
        {
            return $"Website: {Website}, Username: {Username}, Password: {GetDecodedPassword()}";
        }
        public string ToFileFormat()
        {
            return $"{Website} | {Username} | {EncodedPassword}";
        }
        public static PasswordEntry FromFileFormat(string line)
        {
            string[] parts = line.Split('|');
            if (parts.Length != 3) return null;

            return new PasswordEntry(parts[0], parts[1], Encoding.UTF8.GetString(Convert.FromBase64String(parts[2])))
            {
                EncodedPassword = parts[2]
            };
        }
    }
}
