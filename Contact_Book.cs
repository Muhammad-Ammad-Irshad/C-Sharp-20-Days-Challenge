using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
{
    internal class Contact_Book
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contacts = new Dictionary<string, string>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("---Contact Book---");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Search Contact");
                Console.WriteLine("3. View All Contacts");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        if(contacts.ContainsKey(name))
                        {
                            Console.WriteLine("Contact already exists.");
                        }
                        else
                        {
                            Console.Write("Enter Phone Number: ");
                            string number = Console.ReadLine();
                            contacts.Add(name, number);
                            Console.WriteLine("Contact added successfully.");
                        }
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Enter name to search: ");
                        string searchName = Console.ReadLine();
                        if(contacts.ContainsKey(searchName))
                        {
                            Console.WriteLine($"Phone Number: {contacts[searchName]}");
                        }
                        else
                        {
                            Console.WriteLine("Contact not found.");
                        }
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("All Contacts");
                        if(contacts.Count == 0)
                        {
                            Console.WriteLine("No contacts found.");
                        }
                        else
                        {
                            foreach (var contact in contacts)
                            {
                                Console.WriteLine($"Name: {contact.Key}, Phone: {contact.Value}");

                            }
                        }
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        Console.Write("Enter Name to delete: ");
                        string deleteName = Console.ReadLine();
                        if( contacts.ContainsKey(deleteName))
                        {
                            contacts.Remove(deleteName);
                            Console.WriteLine("Contact deleted succesfully.");
                        }
                        else
                        {
                            Console.WriteLine("Contact not found.");
                        }
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Exiting contact book.");
                        return;
                        
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice. Press any key to Try again.");
                        Console.ReadKey();
                        break;
                }
            }
            
        }
    }
}
