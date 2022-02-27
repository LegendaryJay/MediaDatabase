using System;
using System.Collections.Generic;
using System.Text;
using MediaLibrary.Entities;
using MediaLibrary.IO;
using MediaLibrary.Menu.Core;
using NLog;

namespace MediaLibrary.Menu.Menus
{
    public class MediaMenu : MenuTypes
    {
        private const int ItemsPerPage = 5;
        private readonly MediaFileIo _fileIo;
        private readonly Logger _log = LogManager.GetCurrentClassLogger();
        private List<Media> _medias;
        private int _page;
        private readonly OpenQuestionTuple[] questions;

        public MediaMenu(MediaFileIo fileIo, OpenQuestionTuple[] questions)
        {
            _fileIo = fileIo;
            this.questions = questions;
        }

        private void UpdateMedia()
        {
            _log.Trace("Media updating.");
            _medias = _fileIo.GetAll();
        }

        private void ChangePage(int direction)
        {
            _page = (_page + direction + GetPages()) % GetPages();
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
            return (int) Math.Ceiling(_medias.Count / (double) ItemsPerPage);
        }

        private void DisplayPage()
        {
            UpdateMedia();
            var sb = new StringBuilder();
            sb.AppendLine($"Page {_page + 1} / {GetPages()}");
            for (var i = _page * ItemsPerPage; i < Math.Min((_page + 1) * ItemsPerPage, _medias.Count); i++)
                sb.AppendLine(_medias[i].ToPrettyString());

            Console.WriteLine(sb.ToString());
            _log.Trace("Got list of Media");
        }

        private void Display()
        {
            _page = 0;

            DisplayTypeMenu(
                DisplayPage,
                new CommandTuple("Previous Page", Previous),
                new CommandTuple("Next Page", Next)
            );
        }

        private void Add()
        {
            OpenEndedTypeMenu(
                questions
            );
        }

        public void Run()
        {
            MultipleChoiceTypeMenu(
                "What would you like to do with movies?",
                new CommandTuple("Display Movie", Display),
                new CommandTuple("Add Movie", Add)
            );
        }
    }
}