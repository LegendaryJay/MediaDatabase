using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace MediaLibrary.ConsoleMenus.Multi_purpose
{
    public class DisplayMenu<T> : MenuBase
    {
        private const int ItemsPerPage = 5;
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private string _cachedPage;
        private readonly List<T> _items;
        private int _page;
        private readonly Func<T, string> _toStringFunc;

        public DisplayMenu(List<T> items, Func<T, string> toString, string title, int level) : base(title, level)
        {
            _items = items;
            _toStringFunc = toString;
            ThisMenu.Add("Previous", Previous)
                .Add("Next", Next)
                .Configure(
                    config => { config.WriteHeaderAction = Display; }
                );
            UpdatePage();
        }

        private void ChangePage(int direction)
        {
            _page = (_page + direction + GetPageCount()) % GetPageCount();
            UpdatePage();
            _log.Trace($"Changed Page to {_page}");
        }

        private void Next()
        {
            _log.Trace("Next command activated");
            ChangePage(1);
        }

        private void Previous()
        {
            _log.Trace("Previous command activated");
            ChangePage(-1);
        }

        private int GetPageCount()
        {
            _log.Trace("Got pages");
            return Math.Max(1, (int) Math.Ceiling(_items.Count / (double) ItemsPerPage));
        }

        private void UpdatePage()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Page {_page + 1} / {GetPageCount()}");
            for (var i = _page * ItemsPerPage; i < Math.Min((_page + 1) * ItemsPerPage, _items.Count); i++)
                sb.AppendLine(_toStringFunc(_items[i]));
            _cachedPage = sb.ToString();
            _log.Trace("Got list of Media");
        }

        private void Display()
        {
            Console.WriteLine(_cachedPage);
        }

        public override void Run()
        {
            base.Run();
            Display();
        }
    }                   
}

