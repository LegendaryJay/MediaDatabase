using System;
using MediaLibrary.ConsoleMenus;
using NLog;

namespace MediaLibrary
{
    internal static class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            var menu = new MainMenu();
            menu.Run();
        }
    }
}