using CsvHelper.Configuration;
using NLog;

namespace MediaLibrary.Entities
{
    public class Video : Media
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public string Format{ get; set; }
        public int[] Regions{ get; set; }

        public override string ToPrettyString()
        {
            _log.Debug("Displaying Video beautifully");
            return $" - Movie {Id}: {Title}\n\tFormat: {Format}\n\tRegions: {string.Join(", ", Regions)}";
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