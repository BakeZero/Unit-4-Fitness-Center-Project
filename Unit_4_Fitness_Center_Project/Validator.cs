using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_4_Fitness_Center_Project
{
    internal static class Validator
    {
        public static int GetNumber(int lower, int upper, string arg)
        {
            try
            {
                Console.Write($"{arg} ({lower}-{upper}): ");
                int input = int.Parse(Console.ReadLine());
                if (input >= lower && input <= upper)
                    return input;
                else
                {
                    Console.WriteLine("Input out of range.");
                    return GetNumber(lower, upper, arg);
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid input.");
                return GetNumber(lower, upper, arg);
            }
        }

        public static int GetNumber(string arg)
        {
            try
            {
                Console.Write(arg);
                int input = int.Parse(Console.ReadLine());
                return input;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid input.");
                return GetNumber(arg);
            }
        }
    }
}
