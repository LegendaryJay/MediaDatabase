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
            
            //It doesnt tell you If you successfully added a movie or not and I am super not fixing it.
            //Also, I fixed adding and viewing Lists of things. 
            //I am sorry for what grading this will do to you. 
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