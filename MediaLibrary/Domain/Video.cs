using System;
using System.Collections.Generic;
using CsvHelper.Configuration;
using NLog;

namespace MediaLibrary.Domain
{
    public class Video : Media
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private string _format;
        private List<int> _regions;

        public string Format
        {
            get => _format;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Empty format");
                }
                _format = value;
            }
        }

        public List<int> Regions
        {
            get => _regions;
            set
            {
                if (_regions.Count < 1)
                {
                    throw new Exception("Empty regions");
                }
                _regions = value;
            }
        }

        public override string ToPrettyString()
        {
            _log.Debug("Displaying Video beautifully");
            return $" - Video {Id}: {Title}\n\tFormat: {Format}\n\tRegions: {string.Join(", ", Regions)}";
        }
    }

    public sealed class VideoMap : ClassMap<Video>
    {
        public VideoMap()
        {
            Map(m => m.Id).Index(0).Name("movieId");
            Map(m => m.Title).Index(1).Name("title");
            Map(m => m.Format).Index(2).Name("format");
            Map(m => m.Regions).TypeConverter(new ToIntArrayConverter()).Index(3).Name("regions");
        }
    }
}