using System;
using System.Text;
using MediaLibrary.Menu.MenuRelated.Core;
using Microsoft.Win32;
using NLog;

namespace MediaLibrary.Menu.MenuStuff.Core
{
    public class MenuStructure : MenuStructureTools
    {
        private readonly NLog.Logger _log = LogManager.GetCurrentClassLogger();
        private readonly Action _introAction;
        private readonly CommandTuple[] _complexCommands;
        

        public MenuStructure(Action introAction, params CommandTuple[] complexCommands)
        {
            _log.Debug("MenuStructure created");
            _introAction = introAction;
            _complexCommands = complexCommands;
        }

        public MenuStructure(params CommandTuple[] complexCommands)
        {
            _log.Debug("MenuStructure created");
            _complexCommands = complexCommands;
        }

        public  void Run()
        {
            _log.Trace("MenuStructure Running");
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
                    _log.Debug("exiting");
                    return;
                }

                //validation
                int.TryParse(input, out var selection);
                if (selection < 1 | selection > _complexCommands.Length)
                {
                    _log.Info($"User input failed. Expected between 1 and {_complexCommands.Length} but got {input}");
                    Console.WriteLine("I don't understand, Could you try that again?");
                    continue;
                }
                //result
                _complexCommands[selection -1].Run();
            }
        }
    }
}