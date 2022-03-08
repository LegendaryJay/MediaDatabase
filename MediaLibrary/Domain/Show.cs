using System;
using System.Collections.Generic;
using CsvHelper.Configuration;
using NLog;

namespace MediaLibrary.Domain
{
    public class Show : Media
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private int _seasons;
        private int _episodes;
        private List<string> _writers;

        public int Seasons
        {
            get => _seasons;
            set
            {
                if (value < 1)
                {
                    throw new Exception("Empty seasons");
                }
                _seasons = value;
            }
        }

        public int Episodes
        {
            get => _episodes;
            set
            {
                if (value < 1)
                {
                    throw new Exception("Empty seasons");
                }
                _episodes = value;
            }
        }

        public List<string> Writers
        {
            get => _writers;
            set
            {
                if (value is null || value.Count == 0)
                {
                    throw new Exception("Empty writers");
                }
                _writers = value;
            }
        }


        public override string ToPrettyString()
        {
            _log.Debug("Displaying Show beautifully");
            return
                $" - Movie {Id}: {Title}\n\tSeasons: {Seasons}\n\tTotal Episodes: {Episodes}\n\tWriters: {string.Join(", ", Writers)}";
        }
    }

    public sealed class ShowMap : ClassMap<Show>
    {
        public ShowMap()
        {
            Map(m => m.Id).Index(0).Name("movieId");
            Map(m => m.Title).Index(1).Name("title");
            Map(m => m.Seasons).Index(2).Name("seasons");
            Map(m => m.Episodes).Index(3).Name("episodes");
            Map(m => m.Writers).TypeConverter(new ToStringArrayConverter()).Index(4).Name("writers");
        }
    }
}