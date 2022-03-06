using MediaLibrary.Infrastructure;

namespace MediaLibrary.Application
{
    public class MainMenu : MenuBase
    {
        public MainMenu() : base("Main Menu", 0)
        {
            ThisMenu.Add("Movies", () =>
                    {
                        var mediaMenu = new MediaMenu(MediaType.Movie);
                        mediaMenu.Run();
                    }
                )
                .Add("Shows", () =>
                    {
                        var mediaMenu = new  MediaMenu(MediaType.Show);
                        mediaMenu.Run();
                    }
                )
                .Add("Videos", () =>
                    {
                        var mediaMenu = new MediaMenu(MediaType.Video);
                        mediaMenu.Run();
                    }
                );
        }
    }
}