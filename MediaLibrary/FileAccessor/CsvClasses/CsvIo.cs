using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using MediaLibrary.MediaEntities;
using MediaLibrary.MediaEntities.MediaEnum;
using NLog;

namespace MediaLibrary.FileAccessor.CsvClasses
{
    public class CsvIo<T1, T2> : IFileIo
        where T1 : Media
        where T2 : ClassMap
    {
        private readonly string _filePath;
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public CsvIo(MediaType mediaType)
        {
            _filePath = Path.Combine("../../", "Files", mediaType.ToPluralString() + ".csv");

            ValidateFile();
        }


        public bool WriteFile(List<Media> medias)
        {
            var newMedias = medias.ConvertAll(x => x as T1);
            using var writer = new StreamWriter(_filePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<T2>();
            csv.WriteRecords(newMedias);
            return true;
        }

        public List<Media> GetAllMedia()
        {
            // var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            // {
            //     ShouldQuote = args => false
            // };

            using var reader = new StreamReader(_filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<T2>();
            return csv.GetRecords<T1>().ToList().ConvertAll(x => (Media) x);
        }

        private void CreateFile()
        {
            using var writer = new StreamWriter(_filePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteHeader<T2>();
        }

        private void ValidateFile()
        {
            if (File.Exists(_filePath)) return;
            try
            {
                File.Create(_filePath);

                CreateFile();
            }
            catch (UnauthorizedAccessException e)
            {
                _log.Fatal(e);
                Console.WriteLine("File Unable to be created: no permissions");
                throw new UnauthorizedAccessException();
            }
            catch (IOException e)
            {
                _log.Fatal(e);
                Console.WriteLine("File Unable to be created: IO problem");
                throw new IOException();
            }
        }
    }
}