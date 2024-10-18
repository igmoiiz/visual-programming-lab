using System;

namespace EvenOrOddChecker
{
    class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("Enter a Number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            if(number % 2 == 0)
            {
                Console.WriteLine("The number " + number + " is even.");
            }
            else
            {
                Console.WriteLine("The number " + number + " is odd.");
            }
        }
    }
}