using CsvHelper.Configuration;
using MediaLibrary.FileAccessor.CsvClasses.SpecialConversion;
using MediaLibrary.MediaEntities;

namespace MediaLibrary.FileAccessor.CsvClasses.Maps
{
    public sealed class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Map(m => m.Id).Index(0).Name("movieId");
            Map(m => m.Title).Index(1).Name("title");
            Map(m => m.Genres).TypeConverter(new ToStringArrayConverter())
                .Index(2).Name("genres");
        }
    }
}