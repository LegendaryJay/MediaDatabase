using System;
using System.Collections.Generic;
using CsvHelper.Configuration;

namespace MediaLibrary.Entities
{
    public class Movie
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public List<string> Genres { get; set; }

        public string ToPrettyString()
        {
            return $" - Movie {Id}: {Title}\n\t{string.Join(", ", Genres)}";
        }
    }
    public sealed class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Map(m => m.Id).Index(0).Name("movieId");
            Map(m => m.Title).Index(1).Name("title");
            Map(m =>  m.Genres).Index(2).Name("genres");
        }
    }
}