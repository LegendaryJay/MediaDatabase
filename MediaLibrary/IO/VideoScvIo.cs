using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using CsvHelper;
using MediaLibrary.Entities;
using NLog;

namespace MediaLibrary.IO
{
    public class VideoScvIo : MediaScvIo
    {
        private readonly NLog.Logger _log = LogManager.GetCurrentClassLogger();
        public VideoScvIo() : base("Videos.csv") { }
        protected override void FileWrite(IEnumerable<Media> media)
        {
            using var writer = new StreamWriter(Filename);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<VideoMap>();
            csv.WriteRecords(media);
        }

        protected override List<Media> FileRead()
        {
            using var reader = new StreamReader(Filename);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<MovieMap>();

            return csv.GetRecords<Media>().ToList();
        }
    }
}