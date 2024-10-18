using System;

namespace Zenex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the First Number:");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the Second Number:");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double resultAddition = 0;
            double resultSubtraction = 0;
            double resultDivision = 0;
            double resultMultiplication = 0;

            //  addition
            resultAddition = num1 + num2;
            Console.WriteLine("The Sum is: " + resultAddition);
            //  subtraction
            resultSubtraction = num1 - num2;
            Console.WriteLine("The Difference is: " + resultSubtraction);
            //  multiplication
            resultMultiplication = num1 * num2;
            Console.WriteLine("The Product is: " + resultMultiplication);
            //  division
            if (num2 == 0)
            {
                Console.WriteLine("Error: Cannot divide by zero!");
            }
            else
            {
                resultDivision = num1 / num2;
                Console.WriteLine("The Division result is: " + resultDivision);
            }
        }
    }
}