using System;
using System.Collections.Generic;
using System.Linq;
using MediaLibrary.FileAccessor;
using MediaLibrary.MediaEntities;
using NLog;

namespace MediaLibrary.FileInteractions
{
    public class MediaFileIo
    {
        private readonly IFileIo _fileIo;
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public MediaFileIo(IFileIo fileIo)
        {
            _fileIo = fileIo;
        }

        public void AddMedia(Media newMedia)
        {
            if (newMedia is null)
            {
                Console.WriteLine("Something went wrong :(");
                return;
            }

            _log.Trace("New media being created");

            var medias = GetAll();
            _log.Trace("Got all Media");

            var lastId = 0;
            if (medias.Count > 0)
            {
                lastId = medias.Select(movie => movie.Id).Max();

                if (medias.Any(media => media.Title == newMedia.Title))
                {
                    _log.Info($"Repeat Media input. user input: {newMedia.Title}");
                    Console.WriteLine("Um, I think that one already exists :(");
                    return;
                }
            }

            _log.Debug($"Media's Highest ID is {lastId}");

            newMedia.Id = lastId + 1;
            medias.Add(newMedia);


            Console.WriteLine(_fileIo.WriteFile(medias) ? "Successfully Recorded!" : "Something went wrong");
            _log.Info("New Media Added.");
        }

        public List<Media> GetAll()
        {
            _log.Trace("Movies Pulled from records");
            return _fileIo.GetAllMedia() ?? new List<Media>();
        }
    }
}