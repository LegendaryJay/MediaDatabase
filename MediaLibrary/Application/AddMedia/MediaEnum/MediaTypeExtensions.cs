using System;

namespace MediaLibrary.Application.AddMedia.MediaEnum
{
    public static class MediaTypeExtensions
    {
        public static string ToPluralString(this MediaType mt)
        {
            return mt switch
            {
                MediaType.Movie => "movies",
                MediaType.Video => "videos",
                MediaType.Show => "shows",
                _ => throw new ArgumentOutOfRangeException(nameof(mt), mt, null)
            };
        }
    }
}