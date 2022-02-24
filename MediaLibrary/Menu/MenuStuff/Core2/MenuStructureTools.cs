using System;
using System.Collections.Generic;
using MediaLibrary.Menu.MenuStuff.Core;
using NLog;

namespace MediaLibrary.Menu.MenuStuff.Core2
{
    public abstract class MenuStructureTools
    {
        private readonly NLog.Logger _log = LogManager.GetCurrentClassLogger();
        private const string ExitString = "x";
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
                    _log.Trace($"finished with {inputs.Count} items");
                    return inputs;
                }
                inputs.Add(input);

            } while (true);
        }

    }
}