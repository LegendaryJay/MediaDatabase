using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace MediaLibrary.Domain
{
    public abstract class Media
    {
        private string _title;
        public int Id { get; set; }

        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Empty string");
                }
                _title = value;
            }
        }

        public abstract string ToPrettyString();
    }

    public class ToStringArrayConverter : TypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return text == "" ? new List<string>() : text.Split('|').ToList();
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return string.Join("|", (List<string>) value);
        }
    }

    public class ToIntArrayConverter : TypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            return text == ""
                ? new List<int>()
                : text.Split('|').ToList().ConvertAll(x =>
                    int.TryParse(x, out var returnVal)
                        ? returnVal
                        : throw new FormatException()
                );
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return string.Join("|", (List<int>) value);
        }
    }
}