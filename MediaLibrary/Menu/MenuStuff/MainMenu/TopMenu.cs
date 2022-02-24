using MediaLibrary.Menu.MenuStuff.Core;
using MediaLibrary.Menu.MenuStuff.Core2;
using Xunit.Sdk;

namespace MediaLibrary.Menu.MenuStuff.MainMenu
{
    public class TopMenu : MenuTypes
    {
        public void Run()
        {
            MultipleChoiceTypeMenu(
                "Welcome! Please choose what you want to do!",
                
                );
        }
    }
}