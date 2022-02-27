using System.Collections.Generic;
using MediaLibrary.Entities;

namespace MediaLibrary.IO
{
    public interface IFileIo
    {
        public void CreateFile();
        public void WriteFile(List<Media> medias);
        public IEnumerable<Media> GetAllMedia();
    }
}