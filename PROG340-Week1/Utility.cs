using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG340_Week1
{
    public static class Utility
    {
        public static void Print(string input) => Console.WriteLine(input);

        public static void Print(string input, bool newline, ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.Write(input);

            if(newline) Console.WriteLine();
        }

        public static void ClearConsole() => Console.Clear();

        public static void ConsoleSpacer() => Print("-------------------------------------------------", true, ConsoleColor.DarkGray);

        static bool IsDigit(string input)
        {
            char[] char_array = input.ToArray();

            bool digit = false;
            bool[] digits = new bool[char_array.Length];
            int index = 0;

            foreach (char c in char_array)
            {
                if (Char.IsDigit(c)) digits[index] = true;

                index++;
            }

            digit = digits.All(i => i == true);

            return digit;
        }

        static int GetIntInput()
        {
            string input = Console.ReadLine();
            if (IsDigit(input))
            {
                return Convert.ToInt32(input);
            }
            else
            {
                ConsoleSpacer();
                Print("{ ERROR } - input contains non-digit character // re-enter the input: ", false, ConsoleColor.Red);
                return GetIntInput();
            }
        }

        public static bool BoolQuestion(string question, string confirm, string cancel)
        {
            bool result = false;

            Print($"{question} Confirm/Cancel: {confirm}/{cancel} :", false);
            string answer = Console.ReadLine().ToLower();
            if (answer == confirm) result = true;
            if (answer == cancel) result = false;

            return result;
        }

        public static int Question(string question, string[] answers)
        {
            Print(question, true, ConsoleColor.Green);

            ConsoleSpacer();

            int index = 0;
            foreach (string answer in answers)
            {
                index++;
                Print($" {index} ) {answer}", true, ConsoleColor.Yellow);
            }
            ConsoleSpacer();

            Print(" Answer: ", false);

            int input = GetIntInput();

            return input - 1;
        }
    }
}
