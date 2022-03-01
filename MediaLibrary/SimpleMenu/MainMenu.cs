using ConsoleTools;
using MediaLibrary.IO;

namespace MediaLibrary.SimpleMenu
{
    public class MainMenu : MenuBase
    {
        public MainMenu() : base("Main Menu", 0)
        {
            ThisMenu.Add("Movies", () =>
                    {
                        var mediaMenu = new MediaMenu("Movies", MediaFileIoFactory.Movie());
                        mediaMenu.Run();
                    }
                )
                .Add("Shows", () =>
                    {
                        var mediaMenu = new MediaMenu("Shows", MediaFileIoFactory.Show());
                        mediaMenu.Run();
                    }
                )
                .Add("Videos", () =>
                    {
                        var mediaMenu = new MediaMenu("Videos", MediaFileIoFactory.Video());
                        mediaMenu.Run();
                    }
                );
        }
    }
}