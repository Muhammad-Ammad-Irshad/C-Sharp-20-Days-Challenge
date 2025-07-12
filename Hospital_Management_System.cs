using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Day_15
{
    class Patient
    {
        public string Name { get; set; }
        public int Age {  get; set; }
        public string Disease {  get; set; }
        public Patient(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }
        public override string ToString()
        {
            return $"{Name}, {Age}, {Disease}";
        }
        public static Patient FromString(string data)
        {
            var parts = data.Split(',');
            return new Patient(parts[0], int.Parse(parts[1]), parts[2]);
        }
        
    }
    class Doctor
    {
        public string Name { get; set; }
        public string Specialty {  get; set; }
        public Doctor(string name, string specialty)
        {
            Name = name;
            Specialty = specialty;
        }
        public override string ToString()
        {
            return $"{Name}, {Specialty}";
        }
        public static Doctor FromString(string data)
        {
            var parts = data.Split(',');
            return new Doctor(parts[0], parts[2]);
        }
    }
    class Appointment
    {
        public string PatientName { get; set; }
        public string DoctorName {  get; set; }
        public string Date {  get; set; }
        public Appointment(string patientName, string doctorName, string date)
        {
            PatientName = patientName;
            DoctorName = doctorName;
            Date = date;
        }
        public override string ToString()
        {
            return $"{PatientName}, {DoctorName}, {Date}";
        }
        public static Appointment FromString(string data)
        {
            var parts = data.Split(',');
            return new Appointment(parts[0], parts[1], parts[2]);
        }
    }
    class Hospital
    {
        private const string PatientsFile = "Patient.txt";
        private const string DoctorsFile = "doctors.txt";
        private const string AppointmentsFile = "appointments.txt";
        public void AddPatient(Patient patient)
        {
            File.AppendAllText(PatientsFile, patient.ToString() + Environment.NewLine);
            Console.WriteLine("Patient added successfullt.\n");
        }
        public void AddDoctor(Doctor doctor)
        {
            File.AppendAllText(DoctorsFile, doctor.ToString() + Environment.NewLine);
            Console.WriteLine("Doctor added successfully.\n");
        }
        public void AddAppointment(Appointment appointment)
        {
            File.AppendAllText(AppointmentsFile, appointment.ToString() + Environment.NewLine);
            Console.WriteLine("Appointment scheduled successfully.\n");
        }
        public void ViewAllAppointments()
        {
            if (File.Exists(AppointmentsFile))
            {
                string[] lines = File.ReadAllLines(AppointmentsFile);
                Console.WriteLine("\n---Appointments---");
                foreach (string line in lines)
                {
                    Appointment a = Appointment.FromString(line);
                    Console.WriteLine($"Patient: {a.PatientName}, Doctor: {a.DoctorName}, Date: {a.Date}");
                }
            }
            else
            {
                Console.WriteLine("No appointments found.");
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
                Console.WriteLine("\n=== Hospital Management System (Advanced) ===");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Add Doctor");
                Console.WriteLine("3. Schedule Appointment");
                Console.WriteLine("4. View Appointments");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Enter patient name: ");
                        string pName = Console.ReadLine();
                        Console.Write("Enter age: ");
                        int pAge = int.Parse(Console.ReadLine());
                        Console.Write("Enter disease: ");
                        string disease = Console.ReadLine();
                        hospital.AddPatient(new Patient(pName, pAge, disease));
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        Console.Write("Enter doctor name: ");
                        string dName = Console.ReadLine();
                        Console.Write("Enter specialty: ");
                        string specialty = Console.ReadLine();
                        hospital.AddDoctor(new Doctor(dName, specialty));
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Enter patient name: ");
                        string apPatient = Console.ReadLine();
                        Console.Write("Enter doctor name: ");
                        string apDoctor = Console.ReadLine();
                        Console.Write("Enter date (dd-mm-yyyy): ");
                        string apDate = Console.ReadLine();
                        hospital.AddAppointment(new Appointment(apPatient, apDoctor, apDate));
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.Clear();
                        hospital.ViewAllAppointments();
                        Console.ReadKey();
                        break;

                    case "5":
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
