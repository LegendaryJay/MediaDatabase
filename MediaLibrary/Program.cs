using MediaLibrary.IO;
using MediaLibrary.Menu;
using MediaLibrary.Menu.MenuStuff.MainMenu;

namespace MediaLibrary
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MainMenuActions menu = new MainMenuActions();
            menu.RunMenu();
            //TODO 3 Implement with the following features in mind
            //todo Exception Handling
            //todo Logging framework
            //todo Consider creation of additional classes/methods
            //TODO 3 Unit test (at least one test) - TBD
        }
    }
}