using System;
using MediaLibrary.IO;
using MediaLibrary.Menu;
using MediaLibrary.Menu.MenuStuff.MainMenu;
using NLog;

namespace MediaLibrary
{
    internal class Program
    {
        private static readonly NLog.Logger Log = LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            var menu = new MovieMenuActions();
            menu.RunMenu();
            
            //I dont have much to exception handle :(
            //but I know how to do it

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