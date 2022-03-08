using CsvHelper.Configuration;
using MediaLibrary.FileAccessor.CsvClasses.SpecialConversion;
using MediaLibrary.MediaEntities;

namespace MediaLibrary.FileAccessor.CsvClasses.Maps
{
    public sealed class ShowMap : ClassMap<Show>
    {
        public ShowMap()
        {
            Map(m => m.Id).Index(0).Name("movieId");
            Map(m => m.Title).Index(1).Name("title");
            Map(m => m.Seasons).Index(2).Name("seasons");
            Map(m => m.Episodes).Index(3).Name("episodes");
            Map(m => m.Writers).TypeConverter(new ToStringArrayConverter()).Index(4).Name("writers");
        }
    }
}