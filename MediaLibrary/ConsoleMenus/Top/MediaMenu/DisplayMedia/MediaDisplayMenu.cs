using MediaLibrary.ConsoleMenus.Multi_purpose;
using MediaLibrary.FileInteractions;
using MediaLibrary.MediaEntities;
using MediaLibrary.MediaEntities.MediaEnum;

namespace MediaLibrary.ConsoleMenus.Top.MediaMenu.DisplayMedia
{
    public class MediaDisplayMenu : DisplayMenu<Media>
    {
        //private readonly Logger _log = LogManager.GetCurrentClassLogger();
        public MediaDisplayMenu(MediaType mediaType) : base(MediaFileIoFactory.GetFileIo(mediaType).GetAll(),
            x => x.ToPrettyString(), $"{mediaType.ToPluralString()} Display", 2)
        {
            
        }
    }
}