using System;
using MediaLibrary.SimpleMenu;
using NLog;

namespace MediaLibrary
{
    internal class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            //I dont have much to exception handle :(
            //but I know how to do it
            MainMenu menu = new MainMenu();
            menu.Run();
            try
            {
                var i = int.Parse("Candy");
            }
            catch (FormatException e)
            {
                Log.Warn(e);
            }
        }
    }
}