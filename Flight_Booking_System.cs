using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.CodeDom;

namespace Day_17
{
    class Passenger
    {
        public string Name { get; set; }
        public string CNIC { get; set; }
        public int SeatNumber { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}, CNIC: {CNIC}, Seat #: {SeatNumber}";
        }

    }
    class Flight
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        private List<Passenger> passenger = new List<Passenger>();
        private bool[] Seats = new bool[20];
        private string filePath;
        public Flight(string source, string destination)
        {
            Source = source;
            Destination = destination;
            filePath = $"{Source}-{Destination}.txt";
            LoadBookings();
        }
        public void BookSeat()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter CNIC (without -): ");
            string cnic = Console.ReadLine();

            Console.Write("Enter Seat Number (1-20): ");
            int seatNumber = int.Parse(Console.ReadLine());
            if (seatNumber < 1 || seatNumber > Seats.Length)
            {
                Console.WriteLine("Invalid seat number!");
                return;
            }

            if (Seats[seatNumber - 1])
            {
                Console.WriteLine("Seat already booked.");
                return;
            }

            Passenger p = new Passenger { Name = name, CNIC = cnic, SeatNumber = seatNumber };
            passenger.Add(p);
            Seats[seatNumber - 1] = true;

            Console.WriteLine("Booking successful!");
            SaveBookings();
        }
        public void CancelBookings()
        {
            Console.WriteLine("Enter CNIC to cancel booking: ");
            string cnic = Console.ReadLine();
            Passenger found = passenger.Find(p => p.CNIC == cnic);
            if (found != null)
            {
                Seats[found.SeatNumber - 1] = false;
                passenger.Remove(found);
                Console.WriteLine("Booking cancelled");
                SaveBookings();
            }
            else
            {
                Console.WriteLine("Booking not found");
            }
        }
        public void ViewBookings()
        {
            if (passenger.Count == 0)
            {
                Console.WriteLine("No bookings for this flight");
                return;
            }
            Console.WriteLine($"\nBookings for flight: {Source} to {Destination}");
            foreach (var p in passenger)
            {
                Console.WriteLine(p);
            }
        }
        private void SaveBookings()
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var p in passenger)
                {
                    sw.WriteLine($"{p.Name}|{p.CNIC}|{p.SeatNumber}");
                }
            }
        }

        private void LoadBookings()
        {
            if (!File.Exists(filePath)) return;
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Passenger p = new Passenger
                    {
                        Name = parts[0],
                        CNIC = parts[1],
                        SeatNumber = int.Parse(parts[2])
                    };
                    passenger.Add(p);
                    Seats[p.SeatNumber] = true;
                }
            }
        }

    }
    internal class Flight_Booking_System
    {
        static List<Flight> availableFlights = new List<Flight>
        {
            new Flight("Karachi", "Lahore"),
            new Flight("Islamabad", "Dubai"),
            new Flight("Karachi", "Jeddah")
        };
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n---Airline Booking System---");
                Console.WriteLine("Select a flight: ");
                for(int i = 0; i < availableFlights.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {availableFlights[i].Source} -> {availableFlights[i].Destination}");
                }
                Console.WriteLine("0. Exit");
                Console.Write("Enter Choice: ");
                string input = Console.ReadLine();
                if (input == "0") break;
                if(int.TryParse(input, out int index) && index >= 1 && index <= availableFlights.Count)
                {
                    Flight selectedFlight = availableFlights[index - 1];
                    FlightMenu(selectedFlight);
                }
                else
                {
                    Console.WriteLine("Invalid Selection");
                }
            }
        }
        static void FlightMenu(Flight flight)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\n---{flight.Source} -> {flight.Destination}---");
                Console.WriteLine("1. Book Seat");
                Console.WriteLine("2. Cancel Bookings");
                Console.WriteLine("3. View Bookings");
                Console.WriteLine("4. Back to Flight Selection");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        flight.BookSeat();
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        flight.CancelBookings();
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        flight.ViewBookings();
                        Console.ReadKey();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
