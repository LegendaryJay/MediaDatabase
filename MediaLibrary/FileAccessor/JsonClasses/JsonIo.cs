using System;
using System.Collections.Generic;
using System.IO;
using MediaLibrary.MediaEntities;
using MediaLibrary.MediaEntities.MediaEnum;
using Newtonsoft.Json;
using NLog;

namespace MediaLibrary.FileAccessor.JsonClasses
{
    public class JsonIo<T>
        : IFileIo
        where T : Media
    {
        private readonly string _filePath;
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public JsonIo(MediaType mediaType)
        {
            _filePath = Path.Combine("../../", "Files", mediaType.ToPluralString() + ".json");

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