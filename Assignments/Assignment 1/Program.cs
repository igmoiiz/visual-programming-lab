using System;

class Program
{
    static void Main()
    {
        int[,,] matrix = new int[3, 3, 3];
        int sum = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    Console.Write("Enter value for matrix[{0},{1},{2}]: ", i, j, k);
                    matrix[i, j, k] = int.Parse(Console.ReadLine());
                }
            }
        }

        for (int i = 0; i < 3; i++)
        {
            sum += matrix[i, i, i];
        }

        Console.WriteLine("Sum of the diagonal values: " + sum);
    }
}