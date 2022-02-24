using System;
using System.Collections.Generic;
using CsvHelper;
using MediaLibrary.Entities;
using MediaLibrary.IO;
using MediaLibrary.Menu.MenuStuff.Core2;
using NLog;

namespace MediaLibrary.Menu.MenuStuff.Core
{
    public class AddMovieMenuStructure : MenuStructureTools
    {
        private readonly NLog.Logger _log = LogManager.GetCurrentClassLogger();
        private readonly MovieScvIo _movieScvIo;
        
        public AddMovieMenuStructure(MovieScvIo movieScvIo)
        {
            _log.Trace("file IO instantiated");
            _movieScvIo = movieScvIo;

        }

        public override void Run()
        {
            
            //input
            var testName = Input("What is the movies name?");
            if (IsExit(testName))
            {
                _log.Debug("User Exitted");
                return;
            }

            var genres = RepeatInput("List the movie's genres");
            if (genres.Count > 1)
            {
                _log.Debug("Attempting to add new movie");
                _movieScvIo.AddNewMovie(new Movie()
                {
                    Title = testName,
                    Genres = genres
                });
            }
        }
    }
}