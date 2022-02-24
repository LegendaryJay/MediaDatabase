using System;

namespace MediaLibrary.Menu.MenuStuff.Core
{
    public class CommandTuple
    {
        public string Name { get; set; }
        private readonly Action _command;

        public CommandTuple(string name, Action command)
        {
            _command = command;
            Name = name;
        }

        public bool Run()
        {
            _command();
            return true;
        }
    }
}