using System;

namespace StudentMarksCalculator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the number of Students:");
            int numStudents = Convert.ToInt32(Console.ReadLine());

            int[] marks = new int[numStudents];
            int totalMarks = 0;

            for (int i = 0; i < numStudents; i++) 
            {
                Console.WriteLine("Enter marks for Stduent " + (i + 1) + ": ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
                totalMarks += marks[i];
            }

            double averageMarks = (double)totalMarks / numStudents;
            Console.WriteLine("The average marks of the class are: " + averageMarks);
        }
    }
}