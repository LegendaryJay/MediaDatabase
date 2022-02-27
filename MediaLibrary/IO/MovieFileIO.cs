using MediaLibrary.Entities;
using NLog;

namespace MediaLibrary.IO
{
    public class MovieFileIo : MediaFileIo
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public MovieFileIo() : base(new CsvIo<MovieMap>("movies.csv"))
        {
        }
    }
}