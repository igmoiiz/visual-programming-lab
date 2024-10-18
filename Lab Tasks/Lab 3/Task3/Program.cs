using System;

namespace FahreheitToCentigrade
{
    class Program
    {
        static double temperatureConversion(double fahrenheit) 
        {
            return (fahrenheit - 32) * 5 / 9;
        } 

        static void Main()
        {
            Console.WriteLine("Enter the Temperature in Fahrenheit: ");
            double fahrenheit = Convert.ToDouble(Console.ReadLine());

            double centigrade = temperatureConversion(fahrenheit);

            Console.WriteLine("The Temperature in Centigrade is: " + centigrade);
        }
    }
}