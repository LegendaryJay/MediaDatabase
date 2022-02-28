using System.Collections.Generic;
using MediaLibrary.Entities;

namespace MediaLibrary.IO
{
    public interface IFileIo
    {
        public bool WriteFile(List<Media> medias);
        public List<Media> GetAllMedia();
    }
}