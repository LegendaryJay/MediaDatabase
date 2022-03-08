using System;
using System.Collections.Generic;
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
}