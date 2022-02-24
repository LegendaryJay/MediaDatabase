using System;
using System.Collections.Generic;

namespace MediaLibrary.Menu.MenuStuff.Core
{
    public abstract class MenuStructureCore
    {
        protected const string ExitString = "x";
        public abstract void Run();

        protected bool IsExit(string str)
        {
            return string.IsNullOrEmpty(str) ||
                string.Equals(str, ExitString, StringComparison.OrdinalIgnoreCase);
        }

        protected string Input(string question)
        {
            Console.WriteLine(question);
            return Input();
        }
        protected string Input()
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
                    return inputs;
                }
                inputs.Add(input);

            } while (true);
        }

    }
}