using System;

namespace FactorialCalculator
{
    class Program
    {
        static int calculateFactorial(int number)
        {
            if(number == 0 || number == 1)
            {
                return 1;
            }
            else
            {
                return number *  calculateFactorial(number - 1);
            }
        }

        static void Main()
        {
            Console.WriteLine("Enter a Number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number < 0)
            {
                Console.WriteLine("Factorial of a Negative number can not be calculated!");
            } 
            else
            {
                int factorial = calculateFactorial(number);
                Console.WriteLine("The factorial of " + number + " is: " + factorial);
            }
        }
    }
}