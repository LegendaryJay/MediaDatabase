using System;
using System.Collections.Generic;
using CsvHelper.Configuration;
using NLog;
using NLog.Fluent;

namespace MediaLibrary.Entities
{
    
    public class Show : Media
    {
        private readonly NLog.Logger _log = LogManager.GetCurrentClassLogger();
        public int Seasons { get; set; }
        private int Episodes { get; set; }
        private string[] Writers { get; set; }
        

        public override string ToPrettyString()
        {
            _log.Debug("Displaying Show beautifully");
            return $" - Movie {Id}: {Title}\n\tSeasons: {Seasons}\n\tTotal Episodes: {Episodes}\n\tWriters: {string.Join(", ", Writers)}";
        }
    }
    public sealed class ShowMap : ClassMap<Show>
    {
        public ShowMap()
        {
            Map(m => m.Id).Index(0).Name("movieId");
            Map(m => m.Title).Index(1).Name("title");
            Map(m => m.Title).Index(2).Name("seasons");
            Map(m => m.Title).Index(3).Name("episodes");
            Map(m => m.Title).Index(4).Name("writers");

        }
    }
}