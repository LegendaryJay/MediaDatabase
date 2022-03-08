using System.Collections.Generic;
using MediaLibrary.MediaEntities;

namespace MediaLibrary.FileAccessor
{
    public interface IFileIo
    {
        public bool WriteFile(List<Media> medias);
        public List<Media> GetAllMedia();
    }
}