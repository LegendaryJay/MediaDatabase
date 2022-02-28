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
                        var mediaMenu = new MediaMenu("Movies", new MovieFileIo());
                        mediaMenu.Run();
                    }
                )
                .Add("Shows", () =>
                    {
                        var mediaMenu = new MediaMenu("Shows", new ShowFileIo());
                        mediaMenu.Run();
                    }
                )
                .Add("Videos", () =>
                    {
                        var mediaMenu = new MediaMenu("Videos", new VideoFileIo());
                        mediaMenu.Run();
                    }
                );
        }
    }
}