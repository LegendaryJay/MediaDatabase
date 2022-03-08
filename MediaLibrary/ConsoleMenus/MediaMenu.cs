using MediaLibrary.MediaEntities.MediaEnum;
using NLog;

namespace MediaLibrary.ConsoleMenus
{
    public class MediaMenu : MenuBase
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public MediaMenu(MediaType mediaType) : base($"{mediaType} Options", 1)
        {
            ThisMenu.Add("Display All", () =>
                    {
                        var menu = new DisplayMenu(mediaType);
                        menu.Run();
                    }
                )
                .Add("Add to File", () =>
                    {
                        var menu = new AddMenu(mediaType);
                        menu.Run();
                    }
                );
        }
    }
}