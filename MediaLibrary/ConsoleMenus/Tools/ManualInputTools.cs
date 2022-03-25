using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaLibrary.ConsoleMenus.Tools
{
    public static class ManualInputTools
    {
        public const string CancelKey = "X";

        public static bool IsExit(string str)
        {
            return string.IsNullOrWhiteSpace(str)
                   || string.Equals(str.Trim(), CancelKey, StringComparison.OrdinalIgnoreCase);
        }

        public static bool Ask(string question, out string str)
        {
            var input = Input(question);
            if (IsExit(input))
            {
                str = "";
                return false;
            }
            str = input;
            return true;
            
        }
        public static string Input()
        {
            return Console.ReadLine();
        }

        public static string Input(string str)
        {
            Console.WriteLine(str);
            return Console.ReadLine();
        }

        public static List<T> Search<T>(string input, IEnumerable<T> list, Func<T, string> toStringMethod)
        {
            var searchTerms = input.Split(' ');
            return list.Where(
                x => searchTerms.All(
                    y => toStringMethod(x).IndexOf(y, StringComparison.OrdinalIgnoreCase) >= 0
                )
            ).ToList();
        }
    }
}