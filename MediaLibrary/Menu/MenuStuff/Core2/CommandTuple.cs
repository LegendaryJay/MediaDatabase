using System;
using NLog;

namespace MediaLibrary.Menu.MenuStuff.Core
{
    public class CommandTuple
    {
        private readonly NLog.Logger _log = LogManager.GetCurrentClassLogger();
        public string Name { get; set; }
        private readonly Action _command;

        public CommandTuple(string name, Action command)
        {
            _command = command;
            Name = name;
            _log.Debug($"Command tupple created: {name}, {_command.Method.Name}");
        }

        public bool Run()
        {
            _command();
            return true;
        }
    }
}