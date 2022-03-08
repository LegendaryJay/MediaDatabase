using System;
using MediaLibrary.FileAccessor.JsonClasses;
using MediaLibrary.MediaEntities;
using MediaLibrary.MediaEntities.MediaEnum;

namespace MediaLibrary.FileInteractions
{
    public static class MediaFileIoFactory
    {
        public static MediaFileIo GetFileIo(MediaType mediaType)
        {
            return new MediaFileIo(
                mediaType,
                mediaType switch
                {
                    MediaType.Movie => new JsonIo<Movie>(mediaType),
                    MediaType.Video => new JsonIo<Video>(mediaType),
                    MediaType.Show => new JsonIo<Show>(mediaType),
                    _ => throw new ArgumentOutOfRangeException(nameof(mediaType), mediaType, null)
                }
            );
        }
    }
}