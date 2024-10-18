using System;

namespace SquareCalculator
{
    class Program
    {
        static int calculateSquare(int number)
        {
            return number * number;
        }

        static void Main()
        {
            for (int i = 1; i <= 10; i++)
            {
                int square = calculateSquare(i);
                Console.WriteLine("The Square of " + i + " is: " + square);
            }
        }
    }
}