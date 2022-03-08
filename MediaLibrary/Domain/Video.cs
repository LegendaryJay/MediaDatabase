using System;
using System.Collections.Generic;
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
}