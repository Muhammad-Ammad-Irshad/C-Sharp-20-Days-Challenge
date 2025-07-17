using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Cache;

namespace Day_20
{
    class Patient
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Disease { get; set; }
        public override string ToString()
        {
            return $"{ID}, {Name}, {Age}, {Disease}";
        }
        public static Patient FromString(string line)
        {
            var parts = line.Split(',');
            return new Patient
            {
                ID = parts[0],
                Name = parts[1],
                Age = int.Parse(parts[2]),
                Disease = parts[3]
            };
        }
    }
    class Appointment
    {
        public string AppointmentID { get; set; }
        public string PatientID { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public override string ToString()
        {
            return $"{AppointmentID}, {PatientID}, {DoctorName}, {AppointmentDate}";
        }
        public static Appointment FromString(string line)
        {
            var parts = line.Split(',');
            return new Appointment
            {
                AppointmentID = parts[0],
                PatientID = parts[1],
                DoctorName = parts[2],
                AppointmentDate = DateTime.Parse(parts[3])
            };
        }
    }
    class Clinic_System
    {
        private List<Patient> patients = new List<Patient>();
        private List<Appointment> appointments = new List<Appointment>();
        private const string patientFile = "patient.txt";
        private const string appointmentFile = "appointment.txt";
        public void LoadData()
        {
            if (File.Exists(patientFile))
            {
                foreach (var line in File.ReadAllLines(patientFile))
                {
                    patients.Add(Patient.FromString(line));
                }
            }

            if (File.Exists(appointmentFile))
            {
                foreach (var line in File.ReadAllLines(appointmentFile))
                {
                    appointments.Add(Appointment.FromString(line));
                }
            }
        }
        public void SaveData()
        {
            try
            {
                File.WriteAllLines(patientFile, patients.ConvertAll(p => p.ToString()));
                File.WriteAllLines(appointmentFile, appointments.ConvertAll(a => a.ToString()));
                Console.WriteLine("Data saved successfully");
            }catch(IOException ex)
            {
                Console.WriteLine("Error saving Data: " + ex.Message);
            }
        }
        public void AddPatient()
        {
            Console.Write("Enter Patient ID: ");
            string id = Console.ReadLine();
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Disease: ");
            string disease = Console.ReadLine();
            patients.Add(new Patient { ID = id, Name = name, Age = age, Disease = disease });
            Console.WriteLine("Patient added successfully");
            Console.ReadKey();
        }
        public void ViewPatients()
        {
            Console.WriteLine("---Patients List---");
            foreach (var p in patients)
            {
                Console.WriteLine($"{p.ID} - {p.Name}, Age: {p.Age}, Disease: {p.Disease}");
            }
            Console.ReadKey();
        }
        public void SearchPatient()
        {
            Console.Write("Enter Patient ID to search: ");
            string id = Console.ReadLine() ;
            var patient = patients.Find(p => p.ID == id);
            if(patient !=null)
            {
                Console.WriteLine($"Found: {patient.Name}, Age: {patient.Age}, Disease: {patient.Disease}");
            }
            else
            {
                Console.WriteLine("Patient not found");
            }
            Console.ReadKey();
        }
        public void AddAppointment()
        {
            Console.Write("Enter Appointment ID: ");
            string appointmentid = Console.ReadLine() ;
            Console.Write("Enter Patient ID: ");
            string patientid = Console.ReadLine() ;
            Console.Write("Enter Doctor Name: ");
            string docname = Console.ReadLine() ;
            Console.Write("Enter Appointment Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            var patient = patients.Find(p => p.ID == patientid);
            if (patient == null)
            {
                Console.WriteLine("Patient ID not found");
                return;
            }

            appointments.Add(new Appointment
            {
                AppointmentID = appointmentid,
                PatientID = patientid,
                DoctorName = docname,
                AppointmentDate = date
            });

            Console.WriteLine("Appointment created successfully.");
            Console.ReadKey();
        }
        public void ViewAppointments()
        {
            Console.WriteLine("--- Appointments ---");
            foreach(var a in appointments)
            {
                Console.WriteLine($"{a.AppointmentID}: Patient {a.PatientID}, Doctor {a.DoctorName}, Date {a.AppointmentDate.ToShortDateString()}");
            }
            Console.ReadKey();
        }
        public void GenerateReport()
        {
            Console.WriteLine("---Report---");
            Console.WriteLine($"Total Patients: {patients.Count}");
            Console.WriteLine($"Total Appointments: {appointments.Count}");
            Console.ReadKey();
        }
        public void Menu()
        {
            LoadData();
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("---Clinic Management System---");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. View Patient");
                Console.WriteLine("3. Search Appointment");
                Console.WriteLine("4. Add Appointment");
                Console.WriteLine("5. View Appointments");
                Console.WriteLine("6. Generate Report");
                Console.WriteLine("7. Save & Exit");
                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        AddPatient();
                        break;
                    case 2:
                        Console.Clear();
                        ViewPatients();
                        break;
                    case 3:
                        Console.Clear();
                        SearchPatient();
                        break;
                    case 4:
                        Console.Clear();
                        AddAppointment();
                        break;
                    case 5:
                        Console.Clear();
                        ViewAppointments();
                        break;
                    case 6:
                        Console.Clear();
                        GenerateReport();
                        break;
                    case 7:
                        SaveData();
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            } while (choice != 7);
        }
    }
    internal class Clinic_Management_System
    {
        static void Main(string[] args)
        {
            Clinic_System system = new Clinic_System();
            system.Menu();
        }
    }
}
