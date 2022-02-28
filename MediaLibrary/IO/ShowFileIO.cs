using MediaLibrary.Entities;
using NLog;

namespace MediaLibrary.IO
{
    public class ShowFileIo : MediaFileIo
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public ShowFileIo() : base(new CsvIo<Show, ShowMap>("shows.csv"))
        {
            Index = 1;
        }
    }
}