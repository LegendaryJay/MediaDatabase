using MediaLibrary.Entities;
using NLog;

namespace MediaLibrary.IO
{
    public class VideoFileIo : MediaFileIo
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public VideoFileIo() : base(new CsvIo<ShowMap>("Videos.csv"))
        {
        }
    }
}