using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_14
{
    class Patient
    {
        public string Name {  get; set; }
        public int Age { get; set; }
        public string Desease { get; set; }
        public Patient(string name, int age, string desease)
        {
            Name = name;
            Age = age;
            Desease = desease;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Desease: {Desease}");
        }
    }
    class Hospital
    {
        private List<Patient> patients = new List<Patient>();
        public void AddPatient( Patient patient)
        {
            patients.Add(patient);
            Console.WriteLine("Patient added successfully.\n");
        }
        public void SearchPatient(string name)
        {
            var found = false;
            foreach (var patient in patients)
            {
                if(patient.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Patient found: ");
                    patient.DisplayInfo();
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Patient not found.\n");
            }
        }
    }
    internal class Hospital_Management_System
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("---Hospital Management System---");
                Console.WriteLine("1. Add Patient.");
                Console.WriteLine("2. Search Patient.");
                Console.WriteLine("3. Exit.");
                Console.Write("Enter your choice");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Enter patient Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter age: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Enter Disease: ");
                        string disease = Console.ReadLine();
                        hospital.AddPatient(new Patient(name, age, disease));
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Enter patient name to search: ");
                        string SearchName = Console.ReadLine();
                        hospital.SearchPatient(SearchName);
                        Console.ReadKey();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.\n");
                        break;
                }
            }
            Console.WriteLine("Thank you for using the system.");
        }
    }
}
