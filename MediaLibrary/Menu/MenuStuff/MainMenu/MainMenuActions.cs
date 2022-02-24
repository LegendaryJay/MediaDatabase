using System;
using MediaLibrary.IO;
using MediaLibrary.Menu.MenuStuff.Core;
using MediaLibrary.Menu.MenuStuff.DisplayMovies;

namespace MediaLibrary.Menu.MenuStuff.MainMenu 
{
    public class MainMenuActions
    {
        private readonly ScvIo _scvFile;
        private readonly DisplayMovieActions _displayMovieActions;

        public MainMenuActions()
        {
            _scvFile = new ScvIo();
            _displayMovieActions = new DisplayMovieActions(_scvFile.GetAll());
        }
        
        private void DisplayAllMovies()
        {
            _displayMovieActions.UpdateMovies(_scvFile.GetAll());
            _displayMovieActions.RunMenu();
        }

        private void AddNewMovie()
        {
            var addMovie = new AddMovieMenuStructure(_scvFile);
            addMovie.Run();
        }

        private void Welcome()
        {
            Console.WriteLine("Welcome to the world!");
        }

        public void RunMenu()
        {
            var menu = new MenuStructure(
                Welcome,
                new CommandTuple("Display Movies", DisplayAllMovies),
                new CommandTuple("Add Movie", AddNewMovie)
            );
            menu.Run();

        }
    }
}