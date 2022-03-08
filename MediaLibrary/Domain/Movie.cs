using System;
using System.Collections.Generic;
using CsvHelper.Configuration;
using NLog;

namespace MediaLibrary.Domain
{
    public class Movie : Media
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private List<string> _genres;

        public List<string> Genres
        {
            get => _genres;
            set
            {
                if (value is null || value.Count == 0)
                {
                    throw new Exception("Empty genre");
                }
                _genres = value;
            }
        }

        public override string ToPrettyString()
        {
            _log.Debug("Displaying Movie beautifully");
            return $" - Movie {Id}: {Title}\n\tGenres: {string.Join(" - ", Genres)}";
        }
    }
    public sealed class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Map(m => m.Id).Index(0).Name("movieId");
            Map(m => m.Title).Index(1).Name("title");
            Map(m => m.Genres).TypeConverter(new ToStringArrayConverter())
                .Index(2).Name("genres");
        }
    }
}