using System;
using System.Collections.Generic;
using CsvHelper.Configuration;
using NLog;
using NLog.Fluent;

namespace MediaLibrary.Entities
{
    
    public abstract class Media
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public abstract string ToPrettyString();
    }
}