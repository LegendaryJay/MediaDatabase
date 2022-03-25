using MediaLibrary.ConsoleMenus.Multi_purpose;
using MediaLibrary.ConsoleMenus.Top.MediaMenu.AddMedia;
using MediaLibrary.ConsoleMenus.Top.MediaMenu.DisplayMedia;
using MediaLibrary.MediaEntities.MediaEnum;
using NLog;

namespace MediaLibrary.ConsoleMenus.Top.MediaMenu
{
    public class MediaMenu : MenuBase
    {
        private readonly Logger _log = LogManager.GetCurrentClassLogger();

        public MediaMenu(MediaType mediaType) : base($"{mediaType} Options", 1)
        {
            ThisMenu.Add("Display All", () =>
                    {
                        _log.Trace("Display All Selected");
                        new MediaDisplayMenu(mediaType).Run();
                    }
                )
                .Add("Add to File", () =>
                    {
                        _log.Trace("Add to File Selected");
                        new AddMenu(mediaType).Run();

                    }
                )
                .Add("Search", () =>
                {
                    _log.Trace("Search function");
                    new SearchMedia(mediaType, 0).Run();

                }
            );
        }
    }
}