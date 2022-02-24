using System;
using System.Collections.Generic;
using CsvHelper.Configuration;
using NLog;
using NLog.Fluent;

namespace MediaLibrary.Entities
{
    
    public class Video : Media
    {
        private readonly NLog.Logger _log = LogManager.GetCurrentClassLogger();

        private string format;
        private int[] regions;

        public override string ToPrettyString()
        {
            _log.Debug("Displaying Video beautifully");
            return $" - Movie {Id}: {Title}\n\tFormat: {format}\n\tRegions: {string.Join(", ",regions)}";
        }
    }
    public sealed class VideoMap : ClassMap<Video>
    {
        public VideoMap()
        {
            Map(m => m.Id).Index(0).Name("movieId");
            Map(m => m.Title).Index(1).Name("title");
            Map(m => m.Title).Index(2).Name("format");
            Map(m => m.Title).Index(3).Name("regions");
        }
    }
}