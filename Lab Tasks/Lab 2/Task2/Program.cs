using System;

class CommandLinePrinter
{
    static void Main(string[] args)
    {
        //  check if any arguments were passed
        if(args.Length == 0)
        {
            Console.WriteLine("No command line arguments were provided.");
        } 
        else
        {
            Console.WriteLine("Command line arguments recieved: ");

            //  loop through the arguments and print each one of them
            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }
        }
    }
}