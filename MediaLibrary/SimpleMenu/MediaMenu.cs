using MediaLibrary.IO;
using NLog;

namespace MediaLibrary.SimpleMenu
{
    public class MediaMenu : MenuBase
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public MediaMenu(string title, MediaFileIo fileIo) : base($"{title} Options", 1)
        {
            ThisMenu.Add("Display All", () =>
                    {
                        var menu = new DisplayMenu(title, fileIo);
                        menu.Run();
                    }
                )
                .Add("Add to File", () =>
                    {
                        var menu = new AddMenu(fileIo);
                        menu.Run();
                    }
                );
        }
    }
}