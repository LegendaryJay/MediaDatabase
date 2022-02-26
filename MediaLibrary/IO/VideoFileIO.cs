using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using MediaLibrary.Entities;
using NLog;

namespace MediaLibrary.IO
{
    public class VideoFileIo : MediaFileIo
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public VideoFileIo() : base("Videos.csv")
        {
        }
        protected override void WriteMediaToFile(List<Media> medias)
        {
            using var writer = new StreamWriter(Filename);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<VideoMap>();
            csv.WriteRecords(medias);
        }

        protected override List<Media> ReadFile()
        {
            using var reader = new StreamReader(Filename);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<VideoMap>();
            
            return csv.GetRecords<Media>().ToList();
        }

        protected override void CreateFileHeader()
        {
            using var writer = new StreamWriter(Filename);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteHeader<VideoMap>();
        }
    }
}