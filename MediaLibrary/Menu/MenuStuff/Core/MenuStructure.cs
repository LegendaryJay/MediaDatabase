using System;
using System.Text;

namespace MediaLibrary.Menu.MenuStuff.Core
{
    public class MenuStructure : MenuStructureCore
    {
        private readonly Action _introAction;
        private readonly CommandTuple[] _complexCommands;
        

        public MenuStructure(Action introAction, params CommandTuple[] complexCommands)
        {
            _introAction = introAction;
            _complexCommands = complexCommands;
        }

        public MenuStructure(params CommandTuple[] complexCommands)
        {
            _complexCommands = complexCommands;
        }

        public override void Run()
        {
            while (true)
            {
                //intro action
                _introAction();

                var stringBuilder = new StringBuilder();
                //CommandList
                for (var i = 0; i < _complexCommands.Length; i++)
                {
                    stringBuilder.AppendLine("\t" + (i + 1) + ") " + _complexCommands[i].Name);
                }

                var input = Input(stringBuilder.ToString());
                
                //exit validation
                if (IsExit(input))
                {
                    return;
                }

                //validation
                int.TryParse(input, out var selection);
                if (selection < 1 | selection > _complexCommands.Length)
                {
                    Console.WriteLine("I don't understand, Could you try that again?");
                    continue;
                }
                //result
                _complexCommands[selection -1].Run();
            }
        }
    }
}