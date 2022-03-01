using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using MediaLibrary.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;

namespace MediaLibrary.IO
{
    public class JsonIo<T>
        : IFileIo
    where T : Media
    {
        private readonly string _filePath;
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public JsonIo(string fileName)
        {
            _filePath = Path.Combine("../../", "Files", fileName);
            
            ValidateFile();
        }


        public bool WriteFile(List<Media> medias)
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(medias));
            return true;
        }

        public List<Media> GetAllMedia()
        {
            var file = File.ReadAllText(_filePath);
            return new List<Media>(JsonConvert.DeserializeObject<List<T>>(file) ?? new List<T>());
        }

        private void ValidateFile()
        {
            if (File.Exists(_filePath)) return;
            try
            {
                File.Create(_filePath);
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