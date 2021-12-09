using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Calculator().Twice(args[0]));
        }
    }

    public class Calculator
    {
        public string Twice(string s)
        {
            return int.TryParse(s, out var result) ? $"{result * 2}" : "error";
        }
    }
}
