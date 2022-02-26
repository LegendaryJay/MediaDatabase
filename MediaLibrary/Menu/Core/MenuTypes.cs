using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace MediaLibrary.Menu.Core
{
    public class MenuTypes : MenuStructureTools
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        protected void DisplayTypeMenu(Action displayAction, params CommandTuple[] commandTuples)
        {
            displayAction();
            MultipleChoiceTypeMenu(commandTuples);
        }

        public List<string> OpenEndedTypeMenu(params OpenQuestionTuple[] openQuestionTuples)
        {
            var returnVal = new List<string>();
            foreach (var t in openQuestionTuples)
            {
                var input = Input(t);
                if (input is null)
                {
                    return null;
                }
                else
                {
                    returnVal.Add(input);
                }
            }

            return returnVal;
        }

        protected void MultipleChoiceTypeMenu(string intro, params CommandTuple[] commandTuples)
        {
            Console.WriteLine(intro);
            MultipleChoiceTypeMenu(commandTuples);
        }

        protected void MultipleChoiceTypeMenu(params CommandTuple[] commandTuples)
        {
            var stringBuilder = new StringBuilder();
            //CommandList
            for (var i = 0; i < commandTuples.Length; i++)
                stringBuilder.AppendLine("\t" + (i + 1) + ") " + commandTuples[i].Name);

            var input = Input(stringBuilder.ToString());

            //exit validation
            if (IsExit(input))
            {
                _log.Debug("exiting");
                return;
            }

            //validation
            int.TryParse(input, out var selection);
            if ((selection < 1) | (selection > commandTuples.Length))
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