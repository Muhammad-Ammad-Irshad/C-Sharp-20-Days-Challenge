using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
    internal class Car_Rental_System
    {
        class Car
        {
            public int Id { get; }
            public string Model { get; }
            public bool IsAvailable { get; set; }
            public Car(int id, string model)
            {
                Id = id;
                Model = model;
                IsAvailable = true;
            }
            public void Display()
            {
                Console.WriteLine($"ID: {Id} | Model: {Model} | Available: {(IsAvailable ? "Yes" : "No")}");
            }
        }
        class Customer
        {
            public string Name { get; }
            public int? RentedCarId {  get; set; }
            public Customer(string name)
            {
                Name = name;
                RentedCarId = null;
            }
        }
        class Rental
        {
            private List<Car> cars;
            private Customer customer;
            public Rental(List<Car> cars, Customer customer)
            {
                this.cars = cars;
                this.customer = customer;
            }
            public void ViewAvailableCars()
            {
                Console.WriteLine("\nAvailable Cars:");
                foreach (var car in cars)
                {
                    if (car.IsAvailable)
                        car.Display();
                }
            }
            public void BookCar(int carId)
            {
                if(customer.RentedCarId != null)
                {
                    Console.WriteLine("You have already rented a car. Return it first.");
                    return;
                }
                Car car = cars.Find(c => c.Id ==  carId);
                if(car != null && car.IsAvailable)
                {
                    car.IsAvailable = false;
                    customer.RentedCarId = car.Id;
                    Console.WriteLine($"{car.Model} has been rented to {customer.Name}.");
                }
                else
                {
                    Console.WriteLine("Car is not available or Invalid ID.");
                }
            }
            public void ReturnCar()
            {
                if(customer.RentedCarId == null)
                {
                    Console.WriteLine("You have not rented any car.");
                    return;
                }
                Car car = cars.Find(c => c.Id == customer.RentedCarId);
                if(car != null)
                {
                    car.IsAvailable = true;
                    Console.WriteLine($"{car.Model} has been returned successfully.");
                    customer.RentedCarId = null;
                }
            }
        }
        static void Main(string[] args)
        {
            List<Car> carList = new List<Car>
            {
                new Car(1, "Toyota Corolla"),
                new Car(2, "Honda Civic"),
                new Car(3, "Suzuki Alto")
            };
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Customer customer = new Customer(name);
            Rental rental = new Rental(carList, customer);

            int choice;
            do
            {
                
                Console.WriteLine("\n---Car Rental System---");
                Console.WriteLine("1. View Available Cars");
                Console.WriteLine("2. Book a Car");
                Console.WriteLine("3. Return Car");
                Console.WriteLine("4. Exit");
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        rental.ViewAvailableCars();
                        
                        break;
                    case 2:
                        Console.Write("Enter Car Id to book: ");
                        int bookId = int.Parse(Console.ReadLine());
                        rental.BookCar(bookId);
                        break;
                    case 3:
                        
                        rental.ReturnCar();
                        
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Thank you for using our Rent a Car!");
                        break;
                }
            } while (choice != 4);
        }
    }
}
