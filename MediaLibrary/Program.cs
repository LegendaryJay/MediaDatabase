using System;
using MediaLibrary.Menu.Menus;
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
            var topMenu = new TopMenu();
            topMenu.Run();
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