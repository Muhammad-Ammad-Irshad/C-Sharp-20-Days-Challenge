using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1
{
    class CalculatorApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tCalculator App");

            double num1 = GetValidNumber("Enter the First Number: ");
            char operation = GetValidOperator("Enter an operator (+, -, *, /): ");
            double num2 = GetValidNumber("Enter the Second Number: ", operation);
            double result = Calculate(num1, num2, operation);

            Console.WriteLine("Result: {0} {1} {2} = {3}", num1, operation, num2, result);
        }

        static double GetValidNumber(string message, char operation = ' ')
        {
            double number;
            while (true)
            {
                Console.Write(message);
                String input = Console.ReadLine();
                if(double.TryParse(input, out number))
                {
                    if(operation == '/' && number == 0)
                    {
                        Console.WriteLine("Cannot divide by zero. Try again.");
                        continue;
                    }
                    return number;
                }
                else
                {
                    Console.WriteLine("Invalid number. Please enter a valid number.");
                }
            }
        }

        static char GetValidOperator(string message)
        {
            char[] ValidOperator = { '+', '-', '*', '/' };
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if(input.Length == 1 && Array.Exists(ValidOperator, op => op == input[0]))
                {
                    return input[0];
                }
                else
                {
                    Console.WriteLine("Invalid operator. Please enter one of these (+, -, *, /)");
                }
            }
        }

        static double Calculate(double a, double b, char op)
        {
            switch(op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a* b;
                case '/':
                    return a / b;
                default:
                    throw new InvalidOperationException("Unsupported operation");
            }
        }
    }
}
