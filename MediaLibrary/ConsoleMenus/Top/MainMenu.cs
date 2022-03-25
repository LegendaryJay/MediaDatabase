using System;
using MediaLibrary.ConsoleMenus.Multi_purpose;
using MediaLibrary.MediaEntities.MediaEnum;

namespace MediaLibrary.ConsoleMenus.Top
{
    public class MainMenu : MenuBase
    {
        public MainMenu() : base("Main Menu", 0)
        {
            ThisMenu.Add("Movies", () =>
                    {
                        var mediaMenu = new MediaMenu.MediaMenu(MediaType.Movie);
                        mediaMenu.Run();
                    }
                )
                .Add("Shows", () =>
                    {
                        var mediaMenu = new MediaMenu.MediaMenu(MediaType.Show);
                        mediaMenu.Run();
                    }
                )
                .Add("Videos", () =>
                    {
                        var mediaMenu = new MediaMenu.MediaMenu(MediaType.Video);
                        mediaMenu.Run();
                    }
                )
                .Add("Search All", () =>
                    {
                        new SearchMedia((MediaType[])Enum.GetValues(typeof(MediaType)) as MediaType[] , 0).Run();
                    }
                );
        }
    }
}