using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MediaLibrary.Entities;
using NLog;

namespace MediaLibrary.IO
{
    public abstract class MediaFileIo
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        protected readonly string Filename;

        protected MediaFileIo(string fileTitle)
        {
            Filename = Path.Combine("../../", "Files", fileTitle);

            ValidateFile();
        }

        public bool ValidateFile()
        {
            if (File.Exists(Filename)) return true;
            try
            {
                File.Create(Filename);
                
                CreateFileHeader();
                

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

            protected abstract void WriteMediaToFile(List<Media> medias);
            protected abstract List<Media> ReadFile();
            protected abstract void CreateFileHeader();
        
        
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

                
                WriteMediaToFile(medias);
                _log.Info("New Media Added.");
            }

            public List<Media> GetAll()
            {
                _log.Trace("Movies Pulled from records");
                return ReadFile();
            }
        }
    }