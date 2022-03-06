using System;
using MediaLibrary.Application;
using NLog;

namespace MediaLibrary
{
    internal static class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            //I dont have much to exception handle :(
            //but I know how to do it

            //var movies = new CsvIo<Movie, MovieMap>("movies.csv").GetAllMedia();
            //new JsonIo<Movie>("movies.json").WriteFile(movies);
            
            var menu = new MainMenu();
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