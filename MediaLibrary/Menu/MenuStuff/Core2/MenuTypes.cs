using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaLibrary.Menu.MenuStuff.Core;
using NLog;

namespace MediaLibrary.Menu.MenuStuff.Core2
{
    public class MenuTypes : MenuStructureTools
    {
        private readonly NLog.Logger _log = LogManager.GetCurrentClassLogger();
        public void DisplayTypeMenu(params CommandTuple[] commandTuples)
        {
            commandTuples[0].Run();
            MultipleChoiceTypeMenu(commandTuples.Skip(1).ToArray());
        }

        public List<string> OpenEndedTypeMenu(params string[] questions)
        {
            var returnVal = new List<string>();
            foreach (var t in questions)
            {
                if (t.StartsWith("$"))
                {
                    var listInput = RepeatInput(t.Substring(1));
                    returnVal.Add(string.Join("|", listInput));
                }
                else
                {
                    var input = Input(t);
                    if (IsExit(input))
                    {
                        return returnVal;
                    }
                    returnVal.Add(input);
                }
                
            }

            return returnVal;
        }

        public void MultipleChoiceTypeMenu(string intro, params CommandTuple[] commandTuples)
        {
            Console.WriteLine(intro);
            MultipleChoiceTypeMenu(commandTuples);
        }
        public void MultipleChoiceTypeMenu(params CommandTuple[] commandTuples)
        {
            var stringBuilder = new StringBuilder();
            //CommandList
            for (var i = 0; i < commandTuples.Length; i++)
            {
                stringBuilder.AppendLine("\t" + (i + 1) + ") " + commandTuples[i].Name);
            }

            var input = Input(stringBuilder.ToString());

            //exit validation
            if (IsExit(input))
            {
                _log.Debug("exiting");
                return;
            }

            //validation
            int.TryParse(input, out var selection);
            if (selection < 1 | selection > commandTuples.Length)
            {
                _log.Info($"User input failed. Expected between 1 and {commandTuples.Length} but got {input}");
                Console.WriteLine("I don't understand, Could you try that again?");
                return;
            }

            //result
            commandTuples[selection - 1].Run();
        }
    }
}