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
                        _log.Trace("Display All Selected");
                        new DisplayMenu(mediaType).Run();
                    }
                )
                .Add("Add to File", () =>
                    {
                        _log.Trace("Add to File Selected");
                        new AddMenu(mediaType).Run();

                    }
                );
        }
    }
}