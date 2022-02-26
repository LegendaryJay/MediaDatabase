﻿using System.Collections.Generic;
using CsvHelper.Configuration;
using NLog;

namespace MediaLibrary.Entities
{
    public class Movie : Media
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        public List<string> Genres { get; set; }

        public override string ToPrettyString()
        {
            _log.Debug("Displaying Movie beautifully");
            return $" - Movie {Id}: {Title}\n\tGenres: {string.Join(", ", Genres)}";
        }
    }

    public sealed class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            
            Map(m => m.Id).Index(0).Name("movieId");
            Map(m => m.Title).Index(1).Name("title");
            Map(m => m.Genres).Index(2).Name("genres");
        }
    }
}