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
    public class ShowScvIo : MediaScvIo
    {
        private readonly NLog.Logger _log = LogManager.GetCurrentClassLogger();
        public ShowScvIo() : base("Shows.csv") { }
        protected override void FileWrite(IEnumerable<Media> media)
        {
            using var writer = new StreamWriter(Filename);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<ShowMap>();
            csv.WriteRecords(media);
        }

        protected override List<Media> FileRead()
        {
            using var reader = new StreamReader(Filename);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<ShowMap>();

            return csv.GetRecords<Media>().ToList();
        }
    }
}