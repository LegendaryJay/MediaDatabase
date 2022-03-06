using System.Collections.Generic;

namespace MediaLibrary.Domain
{
    public interface IFileIo
    {
        public bool WriteFile(List<Media> medias);
        public List<Media> GetAllMedia();
    }
}