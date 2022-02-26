using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using MediaLibrary.Entities;
using NLog;

namespace MediaLibrary.IO
{
    public class ShowFileIo : MediaFileIo
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public ShowFileIo() : base("Shows.csv")
        {
        }
        protected override void WriteMediaToFile(List<Media> medias)
        {
            using var writer = new StreamWriter(Filename);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<ShowMap>();
            csv.WriteRecords(medias);
        }

        protected override List<Media> ReadFile()
        {
            using var reader = new StreamReader(Filename);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<ShowMap>();
            
            return csv.GetRecords<Media>().ToList();
        }

        protected override void CreateFileHeader()
        {
            using var writer = new StreamWriter(Filename);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteHeader<ShowMap>();
        }
    }
}