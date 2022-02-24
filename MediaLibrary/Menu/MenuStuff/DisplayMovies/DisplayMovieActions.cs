using System;
using System.Collections.Generic;
using System.Text;
using MediaLibrary.Entities;
using MediaLibrary.Menu.MenuStuff.Core;

namespace MediaLibrary.Menu.MenuStuff.DisplayMovies
{
    public class DisplayMovieActions
    {
        private const int ItemsPerPage = 5;
        private int _page;
        private static List<Movie> _movies;
        private readonly MenuStructure _menuStructure;

        public void UpdateMovies(List<Movie> movies)
        {
            _movies = movies;
        }
        public DisplayMovieActions(List<Movie> movies)
        {
            _movies = movies;
            _page = 0;

            var commandTuples = new CommandTuple[2];
            commandTuples[0] = new CommandTuple("Previous Page", Previous);
            commandTuples[1] = new CommandTuple("Next Page", Next);

            _menuStructure = new MenuStructure(GetStringList, commandTuples);
        }

        public void RunMenu()
        {
            _menuStructure.Run();
        }

        private void Next()
        {
            ChangePage(1);
        }

        private void Previous()
        {
            ChangePage(-1);
        }

        private int GetPages()
        {
            return (int) Math.Ceiling(_movies.Count / (double) ItemsPerPage);
        }

        private void GetStringList()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Page {_page + 1} / {GetPages()}");
            for (int i = _page * ItemsPerPage; i < Math.Min((_page + 1) * ItemsPerPage, _movies.Count); i++)
            {
                sb.AppendLine(_movies[i].ToPrettyString());
            }

            Console.WriteLine(sb.ToString());
        }

        private void ChangePage(int direction)
        {
            _page = (_page + direction + GetPages()) % GetPages();
        }
    }
}