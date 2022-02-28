using System;
using System.Collections.Generic;
using System.Linq;
using MediaLibrary.Entities;
using NLog;

namespace MediaLibrary.IO
{
    public abstract class MediaFileIo
    {
        private readonly IFileIo _fileIo;
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        public int Index;

        protected MediaFileIo(IFileIo fileIo)
        {
            _fileIo = fileIo;
        }

        public void AddMedia(Media newMedia)
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


            _fileIo.WriteFile(medias);
            _log.Info("New Media Added.");
        }

        public List<Media> GetAll()
        {
            _log.Trace("Movies Pulled from records");
            return _fileIo.GetAllMedia();
        }
    }
}