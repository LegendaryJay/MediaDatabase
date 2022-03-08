using System;
using System.Collections.Generic;
using System.Text;
using MediaLibrary.FileInteractions;
using MediaLibrary.MediaEntities;
using MediaLibrary.MediaEntities.MediaEnum;
using NLog;

namespace MediaLibrary.ConsoleMenus
{
    public class DisplayMenu : MenuBase
    {
        private const int ItemsPerPage = 5;
        private readonly MediaFileIo _fileIo;
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private string _cachedPage;
        private List<Media> _medias;
        private int _page;

        public DisplayMenu(MediaType mediaType) : base($"{mediaType.ToPluralString()} Display", 2)
        {
            _fileIo = MediaFileIoFactory.GetFileIo(mediaType);
            UpdatePage();
            ThisMenu.Add("Previous", Previous)
                .Add("Next", Next)
                .Configure(
                    config => { config.WriteHeaderAction = Display; }
                );
        }

        private void UpdateMedia()
        {
            _log.Trace("Media updating.");
            _medias = _fileIo.GetAll();
        }

        private void ChangePage(int direction)
        {
            _page = (_page + direction + GetPages()) % GetPages();
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

        private int GetPages()
        {
            _log.Trace("Got pages");
            return Math.Max(1, (int) Math.Ceiling(_medias.Count / (double) ItemsPerPage));
        }

        private void UpdatePage()
        {
            UpdateMedia();
            var sb = new StringBuilder();
            sb.AppendLine($"Page {_page + 1} / {GetPages()}");
            for (var i = _page * ItemsPerPage; i < Math.Min((_page + 1) * ItemsPerPage, _medias.Count); i++)
                sb.AppendLine(_medias[i].ToPrettyString());
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