using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    internal class Library_Management
    {
        static List<string> books = new List<string>();
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("---Library Book Inventory---");
                Console.WriteLine("1. Add Books");
                Console.WriteLine("2. Remove Books");
                Console.WriteLine("3. Search Book by Title");
                Console.WriteLine("4. View All Books");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice (1-5): ");

                bool isValid = int.TryParse(Console.ReadLine(), out choice);
                if (!isValid || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
                }
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        RemoveBook();
                        break;
                    case 3:
                        SearchBook();
                        break;
                    case 4:
                        ViewAllBooks();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        break;
                }
                if (choice != 5)
                {
                    Console.WriteLine("\nPress Enter to return to the menu");
                    Console.ReadLine();
                }
            } while (choice != 5);
        }
        static void AddBook()
        {
            Console.Write("Enter the book title to add: ");
            string title = Console.ReadLine();
            if(!string.IsNullOrEmpty(title))
            {
                books.Add(title);
                Console.WriteLine($"'{title}' has been added to the inventory.");
            }
            else
            {
                Console.WriteLine("Invalid input. Title cannot be empty.");
            }
        }
        static void RemoveBook()
        {
            Console.WriteLine("Enter the book title to remove: ");
            string title = Console.ReadLine();
            if (books.Remove(title))
            {
                Console.WriteLine($"'{title}' has been removed from the inventory.");
            }
            else
            {
                Console.WriteLine($"'{title}' not found in the inventory.");
            }
        }
        static void SearchBook()
        {
            Console.Write("Enter the book title to search: ");
            string title = Console.ReadLine();
            bool found = false;
            foreach (string book in books)
            {
                if(book.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine($"Found: {book}");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No matching book found.");
            }
        }
        static void ViewAllBooks()
        {
            if(books.Count == 0)
            {
                Console.WriteLine("No books in the inventory.");
            }
            else
            {
                Console.WriteLine("Books in Inventory: ");
                foreach(string book in books)
                {
                    Console.WriteLine($"-{book}");
                }
            }
        }
    }
}
