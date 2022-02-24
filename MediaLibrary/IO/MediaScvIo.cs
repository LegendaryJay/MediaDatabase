using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using CsvHelper;
using MediaLibrary.Entities;
using NLog;

namespace MediaLibrary.IO
{
    public class MediaScvIo
    {
        private readonly NLog.Logger _log = LogManager.GetCurrentClassLogger();
        private readonly string _filename = Path.Combine("../../", "Files", "movies.csv");
        public void AddNewMovie(Movie newMovie)
        {
            _log.Trace("New movie being created");   
            
            var movies = GetAll();
            _log.Trace("Got all movies");
            
            var lastId = movies.Select(movie => movie.Id).Max();
            _log.Debug($"Movies Highest ID is {lastId}");
            
            if (movies.Any(movie => movie.Title == newMovie.Title))
            {
                _log.Info($"Repeat movie inputted. user input: {newMovie.Title}");
                Console.WriteLine("Um, I think that one already exists :(");
                return;
            }
            
            newMovie.Id = lastId + 1;
            movies.Add(newMovie);
            using var writer = new StreamWriter(_filename);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<MovieMap>();
            csv.WriteRecords(movies);
            _log.Info("New Movie Added.");
        }
        public List<Movie> GetAll()
        {
            IEnumerable<Movie> records;

            using (var reader = new StreamReader(_filename))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<MovieMap>();

                    records = csv.GetRecords<Movie>().ToList();
                }
            }
            _log.Trace("Movies Pulled from records");
            return new List<Movie>(records);
        }
    }
}