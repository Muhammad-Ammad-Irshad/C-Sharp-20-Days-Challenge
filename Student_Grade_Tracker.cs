using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
    internal class Student_Grade_Tracker
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Student Grade Tracker---");
            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();
            Console.Write("Enter number of subjects: ");
            int subjectCount = int.Parse(Console.ReadLine());
            List<int> marks = new List<int>();
            int total = 0;
            for(int i  = 1; i <= subjectCount; i++)
            {
                Console.WriteLine($"Enter marks for subject {i}: ");
                int mark = int.Parse(Console.ReadLine());
                while( mark < 0 || mark > 100)
                {
                    Console.Write("Invalid input. Enter marks between 0 and 100: ");
                    mark = int.Parse(Console.ReadLine());
                }
                marks.Add( mark );
                total += mark;
            }

            double average = (double)total / subjectCount;
            string grade;
            if (average >= 90)
                grade = "A+";
            else if (average >= 80)
                grade = "A";
            else if (average >= 70)
                grade = "B";
            else if (average >= 60)
                grade = "C";
            else if (average >= 50)
                grade = "D";
            else
                grade = "F";

            Console.WriteLine("\n---Result---");
            Console.WriteLine($"Student Name: {studentName}");
            Console.WriteLine($"Total Marks: {total}/{subjectCount * 100}");
            Console.WriteLine($"Average: {average:F2}");
            Console.WriteLine($"Grade: {grade}");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
