using System;
using System.Collections.Generic;
using NLog;

namespace MediaLibrary.Menu.Core
{
    public abstract class MenuStructureTools
    {
        private const string ExitString = "x";
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        protected static bool IsExit(string str)
        {
            Log.Trace($"Found exitable string: {str}");
            return string.IsNullOrEmpty(str) ||
                   string.Equals(str, ExitString, StringComparison.OrdinalIgnoreCase);
        }

        protected static string Input(string question)
        {
            Console.WriteLine(question);
            return Input();
        }

        protected static string Input(OpenQuestionTuple openQuestionTuple)
        {
            while (true)
            {
                var value = new List<string>();
                var input = LoneInput(openQuestionTuple);
                if (input is null) return value.Count > 1 ? string.Join(",", value) : null;
                value.Add(input);
            }
        }

        private static string LoneInput(OpenQuestionTuple openQuestionTuple)
        {
            var input = Input(openQuestionTuple.Question);
            if (IsExit(input)) return null;

            return openQuestionTuple.Validate(input) ? input : null;
        }

        private static string Input()
        {
            Console.WriteLine("\nTo cancel/exit enter " + ExitString);
            return Console.ReadLine()?.Trim();
        }

        protected List<string> RepeatInput(string question)
        {
            Console.WriteLine(question);
            var inputs = new List<string>();
            do
            {
                var input = Console.ReadLine()?.Trim();
                if (IsExit(input))
                {
                    Log.Trace($"finished with {inputs.Count} items");
                    return inputs;
                }

                inputs.Add(input);
            } while (true);
        }
    }
}