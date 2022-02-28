using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace MediaLibrary.Entities
{
    public abstract class Media
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public abstract string ToPrettyString();
    }
}

public class ToStringArrayConverter : TypeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        return text == "" ? new string[]{} : text.Split('|').ToList();

    }

    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        return string.Join(",", value);
    }
}