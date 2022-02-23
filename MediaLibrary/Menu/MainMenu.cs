using System;
using System.Collections.Generic;
using CsvHelper;
using MediaLibrary.Entities;
using MediaLibrary.IO;

namespace MediaLibrary.Menu
{
    public class MainMenu
    {
        private string _exitString = "X";
        private readonly List<string> _options = new List<string> {"Display Movies", "Add Movie"};
        private ScvIo _scvFile;


        public MainMenu()
        {
            _scvFile = new ScvIo();
        }

        public void Menu()
        {
            var hasFinished = false;
            do
            {
                var selectionNumber = -1;
                Console.WriteLine("Please select one:");
                for (int i = 0; i < _options.Count; i++)
                {
                    Console.WriteLine("\t" + (i + 1) + ") " + _options[i]);
                }

                Console.WriteLine(_exitString + " to exit");
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) || input.ToUpper().Equals(_exitString))
                {
                    Console.WriteLine("K thnks bye");
                    hasFinished = true;
                    break;
                }

                try
                {
                    selectionNumber = int.Parse(input);
                }
                catch (Exception e)
                {
                    //ignored
                }

                if (selectionNumber <= 0 || selectionNumber > _options.Count)
                {
                    Console.WriteLine("Something went wrong, could you try again?");
                    continue;
                }

                Console.WriteLine($"{_options[selectionNumber - 1]} selected");

                switch (selectionNumber)
                {
                    case 1:
                        DisplayAllMovies();
                        break;
                    case 2:
                        AddNewMovie();
                        break;
                }
            } while (!hasFinished);
        }

        private void DisplayAllMovies()
        {
            const int listLength = 5;
            var movies = _scvFile.GetAll();
            var pages = (int) Math.Ceiling(movies.Count / (double) listLength);
            var page = 0;
            var input = "";
            var hasFinished = false;

            do
            {
                Console.WriteLine($"Page {page + 1} / {pages}");
                for (int i = page * listLength; i < Math.Min((page + 1) * listLength, movies.Count); i++)
                {
                    Console.WriteLine(movies[i].ToPrettyString());
                }


                Console.WriteLine();
                Console.WriteLine("1) Previous Page");
                Console.WriteLine("2) Next Page");
                Console.WriteLine($"{_exitString} to exit.");
                input = Console.ReadLine();
                var pageChange = 0;
                switch (input)
                {
                    case "1":
                        pageChange = -1;
                        break;
                    case "2":
                        pageChange = 1;
                        break;
                    default:
                        if (input.ToUpper() != _exitString)
                        {
                            Console.WriteLine("Something went wrong, could you try again?");
                        }
                        else
                        {
                            hasFinished = true;
                        }

                        break;
                }

                page = (page + pageChange + pages) % pages;
            } while (!hasFinished);
        }

        private void AddNewMovie()
        {
            Console.WriteLine("Mhat is the movies name?");
            var testName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(testName))
            {
                Console.WriteLine("Something went wrong. Cancelling.");
                return;
            }

            Console.WriteLine("List all the genres!");
            Console.WriteLine(_exitString + " to Exit");

            var genres = new List<string>();
            do
            {
                var testgenre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(testgenre) || testgenre.ToUpper() == _exitString)
                {
                    if (genres.Count > 0)
                    {
                        var movie = new Movie
                        {
                            Genres = genres,
                            Title = testName
                        };
                        _scvFile.AddNewMovie(movie);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong :(");
                        return;
                    }
                }
                genres.Add(testgenre);
            } while (true);
        }
    }
}