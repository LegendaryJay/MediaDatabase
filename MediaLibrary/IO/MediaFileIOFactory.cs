using MediaLibrary.Entities;

namespace MediaLibrary.IO
{
    public static class MediaFileIoFactory
    {
        public static MediaFileIo Movie()
        {
            return new MediaFileIo(0, new JsonIo<Movie>("movies.json"));
        }
        public static MediaFileIo Show()
        {
            return new MediaFileIo(1, new JsonIo<Show>("movies.json"));
        }
        public static MediaFileIo Video()
        {
            return new MediaFileIo(2, new JsonIo<Video>("movies.json"));
        }
    }
}