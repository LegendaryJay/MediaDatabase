using System;
using MediaLibrary.IO;
using MediaLibrary.Menu.MenuStuff.Core;
using MediaLibrary.Menu.MenuStuff.DisplayMovies;
using NLog;

namespace MediaLibrary.Menu.MenuStuff.MainMenu 
{
    public class MainMenuActions
    {
        private readonly NLog.Logger _log = LogManager.GetCurrentClassLogger();
        private readonly MovieScvIo _scvFile;
        private readonly DisplayMovieActions _displayMovieActions;

        public MainMenuActions()
        {
            _log.Trace("MainMenuActions Instantiated");
            _scvFile = new MovieScvIo();
            _displayMovieActions = new DisplayMovieActions(_scvFile.GetAll());
        }
        
        private void DisplayAllMovies()
        {
            _log.Trace("displaying all movies");
            _displayMovieActions.UpdateMovies(_scvFile.GetAll());
            _displayMovieActions.RunMenu();
        }

        private void AddNewMovie()
        {
            _log.Trace("Adding new movies");
            var addMovie = new AddMovieMenuStructure(_scvFile);
            addMovie.Run();
        }

        private void Welcome()
        {
            Console.WriteLine("Welcome to the world!");
        }

        public void RunMenu()
        {
            _log.Trace("Running Main Menu");
            var menu = new MenuStructure(
                Welcome,
                new CommandTuple("Display Movies", DisplayAllMovies),
                new CommandTuple("Add Movie", AddNewMovie)
            );
            menu.Run();

        }
    }
}