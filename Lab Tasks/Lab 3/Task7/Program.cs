using System;

namespace SmallestNumberFinder
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter First Number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Third Number: ");
            int num3 = Convert.ToInt32(Console.ReadLine());

            int smallest = num1;

            if(num2 < smallest)
            {
                smallest = num2;
            }

            if (num3 < smallest) 
            {
                smallest = num3;
            }
            Console.WriteLine("The Smallest Number among the three is: " + smallest);
        }
    }
}