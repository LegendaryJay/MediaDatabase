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
    public abstract class MediaScvIo
    {
        private readonly NLog.Logger _log = LogManager.GetCurrentClassLogger();
        protected readonly string Filename;

        protected MediaScvIo(string fileTitle)
        {
            
            Filename = Path.Combine("../../", "Files", fileTitle);
        }

        public void AddRow(Media newMedia)
        {
            _log.Trace("New media being created");   
            
            var medias = GetAll();
            _log.Trace("Got all Media");
            
            var lastId = medias.Select(movie => movie.Id).Max();
            _log.Debug($"Media's Highest ID is {lastId}");
            
            if (medias.Any(media => media.Title == newMedia.Title))
            {
                _log.Info($"Repeat Media input. user input: {newMedia.Title}");
                Console.WriteLine("Um, I think that one already exists :(");
                return;
            }
            
            newMedia.Id = lastId + 1;
            medias.Add(newMedia);
            FileWrite(medias);
            _log.Info("New Media Added.");
        }

        protected abstract void FileWrite(IEnumerable<Media> media);
        protected abstract List<Media> FileRead();
        
        public List<Media> GetAll()
        {
            _log.Trace("Movies Pulled from records");
            return FileRead();
        }
    }
}