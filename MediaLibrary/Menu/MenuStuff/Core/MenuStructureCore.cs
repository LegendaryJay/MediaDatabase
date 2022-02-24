using System;
using System.Collections.Generic;
using NLog;

namespace MediaLibrary.Menu.MenuStuff.Core
{
    public abstract class MenuStructureCore
    {
        private readonly NLog.Logger _log = LogManager.GetCurrentClassLogger();
        private const string ExitString = "x";
        public abstract void Run();

        protected bool IsExit(string str)
        {
            _log.Trace($"Found exitable string: {str}");
            return string.IsNullOrEmpty(str) ||
                string.Equals(str, ExitString, StringComparison.OrdinalIgnoreCase);
        }

        protected static string Input(string question)
        {
            Console.WriteLine(question);
            return Input();
        }

        private static string Input()
        {
            Console.WriteLine("\nTo Cancel/Exit Press " + ExitString);
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
                    _log.Trace($"finished with {inputs.Count} items");
                    return inputs;
                }
                inputs.Add(input);

            } while (true);
        }

    }
}