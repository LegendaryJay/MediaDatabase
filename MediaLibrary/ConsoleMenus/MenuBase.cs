using System;
using ConsoleTools;

namespace MediaLibrary.ConsoleMenus
{
    public abstract class MenuBase
    {
        protected readonly ConsoleMenu ThisMenu;

        protected MenuBase(string title, int level)
        {
            ThisMenu = new ConsoleMenu(new string[] { }, level)
                .Add("Close", ConsoleMenu.Close)
                .Configure(
                config =>
                {
                    config.EnableBreadcrumb = true;
                    config.Title = title;
                    config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" > ", titles));
                    
                }
            );
        }

        public virtual void Run()
        {
            ThisMenu.Show();
        }
    }
}