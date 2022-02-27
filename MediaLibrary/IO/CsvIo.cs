using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using MediaLibrary.Entities;
using MediaLibrary.Menu.Core;
using NLog;

namespace MediaLibrary.IO
{
    public class CsvIo<T> : IFileIo
    {
        private readonly string _filePath;
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public CsvIo(string fileName)
        {
            _filePath = Path.Combine("../../", "Files", fileName);
            ValidateFile();
        }

        private bool ValidateFile()
        {
            if (File.Exists(_filePath)) return true;
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

            return true;
        }

        public void CreateFile()
        {
            using var writer = new StreamWriter(_filePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteHeader<T>();
        }
        

        public void WriteFile(List<Media> medias)
        {
            using var writer = new StreamWriter(_filePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<ShowMap>();
            csv.WriteRecords(medias);
        }

        public IEnumerable<Media> GetAllMedia()
        {
            using var reader = new StreamReader(_filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<MovieMap>();

            return csv.GetRecords<Media>().ToList();
        }
    }
}