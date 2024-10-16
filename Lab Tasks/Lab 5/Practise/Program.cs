using System;
namespace Practise
{
    class Practise
    {
        static void Main()
        {
            double a = 98;
            double b = 0;   
            double result = 0;
            try
            {
                result = SafeDivision(a, b);
                Console.WriteLine($"{a} divided by {b} = {result}");
            } catch(DivideByZeroException e)
            {
                Console.WriteLine("Divided by Zero Attempted!");
            }
        }
        static double SafeDivision(double x, double y)
        {
            if (y == 0)
                throw new System.DivideByZeroException();
            return x / y;
        }
    }
}