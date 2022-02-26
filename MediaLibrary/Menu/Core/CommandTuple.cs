using System;
using NLog;

namespace MediaLibrary.Menu.Core
{
    public class CommandTuple
    {
        private readonly Action _command;
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public CommandTuple(string name, Action command)
        {
            _command = command;
            Name = name;
            _log.Debug($"Command tupple created: {name}, {_command.Method.Name}");
        }

        public string Name { get; set; }

        public bool Run()
        {
            _command();
            return true;
        }
    }
}