using CsvHelper.Configuration;
using MediaLibrary.FileAccessor.CsvClasses.SpecialConversion;
using MediaLibrary.MediaEntities;

namespace MediaLibrary.FileAccessor.CsvClasses.Maps
{
    public sealed class VideoMap : ClassMap<Video>
    {
        public VideoMap()
        {
            Map(m => m.Id).Index(0).Name("movieId");
            Map(m => m.Title).Index(1).Name("title");
            Map(m => m.Format).Index(2).Name("format");
            Map(m => m.Regions).TypeConverter(new ToIntArrayConverter()).Index(3).Name("regions");
        }
    }
}