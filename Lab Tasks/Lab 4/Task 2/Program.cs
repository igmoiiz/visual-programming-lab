//using System;

//class Program
//{
//    static void Main()
//    {
//        int[,] myArray = new int[3, 4]
//        {
//            {1, 2, 3, 4},
//            {5, 6, 7, 8},
//            {9, 10, 11, 12}
//        };

//        Print2DArray(myArray);
//    }

//    static void Print2DArray(int[,] array)
//    {
//        for (int i = 0; i < array.GetLength(0); i++)
//        {
//            for (int j = 0; j < array.GetLength(1); j++)
//            {
//                Console.Write(array[i, j] + " ");
//            }
//            Console.WriteLine();
//        }
//    }
//}

//using System;

//class Program
//{
//    static void Main()
//    {
//        string[] strings = { "hello", "and", "welcome ", "to", "Air University", "Multan Campus!" };

//        string mergedString = Merger(strings);
//        Console.WriteLine(mergedString);
//    }

//    static string Merger(string[] strings)
//    {
//        string result = "";
//        foreach (string str in strings)
//        {
//            result += str + " ";
//        }
//        return result.Trim();
//    }
//}

//using System;
//using System.Linq;
//using System.Text.RegularExpressions;

//class Program
//{
//    static void Main()
//    {
//        string input = "This is a sample sentence with some words";

//        string[] extractedWords = ExtractWords(input);

//        Console.WriteLine("Extracted words:");
//        foreach (string word in extractedWords)
//        {
//            Console.WriteLine(word);
//        }
//    }

//    static string[] ExtractWords(string input)
//    {
//        string[] words = input.Split(' ');

//        return words.Where(word =>
//            word.Length >= 4 && word.Length <= 5 && ContainsVowel(word))
//            .ToArray();
//    }

//    static bool ContainsVowel(string word)
//    {
//        return Regex.IsMatch(word, "[aeiouAEIOU]");
//    }

//    static bool IsVowel(char c)
//    {
//        return "aeiouAEIOU".Contains(c);
//    }
//}

//using System;

//class Program
//{
//    static void Main()
//    {
//        int[] ratings = { 3, 5, 4, 2, 1, 5, 3, 4, 2, 1, 3, 4 };

//        int[] frequency = new int[5];

//        foreach (int rating in ratings)
//        {
//            frequency[rating - 1]++;
//        }

//        for (int i = 0; i < frequency.Length; i++)
//        {
//            Console.WriteLine($"Response {i + 1} given by: {frequency[i]} people");
//        }
//    }
//}

using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int decimalNumber = int.Parse(Console.ReadLine());

        string binaryNumber = DecimalToBinary(decimalNumber);
        Console.WriteLine($"Binary equivalent: {binaryNumber}");

        int convertedDecimal = BinaryToDecimal(binaryNumber);
        Console.WriteLine($"Converted decimal: {convertedDecimal}");
    }

    static string DecimalToBinary(int decimalNumber)
    {
        string binary = "";
        while (decimalNumber > 0)
        {
            int remainder = decimalNumber % 2;
            binary = remainder + binary;
            decimalNumber /= 2;
        }
        return binary;
    }

    static int BinaryToDecimal(string binaryNumber)
    {
        int decimalValue = 0;
        int power = 0;

        for (int i = binaryNumber.Length - 1; i >= 0; i--)
        {
            decimalValue += (int)(binaryNumber[i] - '0') * (int)Math.Pow(2, power);
            power++;
        }

        return decimalValue;
    }
}