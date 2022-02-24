using System;
using System.Collections.Generic;
using CsvHelper;
using MediaLibrary.Entities;
using MediaLibrary.IO;

namespace MediaLibrary.Menu.MenuStuff.Core
{
    public class AddMovieMenuStructure : MenuStructureCore
    {
        private readonly ScvIo _scvIo;
        
        public AddMovieMenuStructure(ScvIo scvIo)
        {
            _scvIo = scvIo;

        }

        public override void Run()
        {
            
            //input
            var testName = Input("What is the movies name?");
            if (IsExit(testName))
            {
                return;
            }

            var genres = RepeatInput("List the movie's genres");
            if (genres.Count > 1)
            {
                _scvIo.AddNewMovie(new Movie()
                {
                    Title = testName,
                    Genres = genres
                });
            }
        }
    }
}