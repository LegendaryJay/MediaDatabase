using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using MediaLibrary.Entities;

namespace MediaLibrary.IO
{
    public class ScvIo
    {
        private readonly string _filename = Path.Combine("../../", "Files", "movies.csv");
        public void AddNewMovie(Movie newMovie)
        {
            
            var movies = GetAll();
            var lastId = movies.Select(movie => movie.Id).Max();
            if (movies.Any(movie => movie.Title == newMovie.Title))
            {
                Console.WriteLine("Um, I think that one already exists :(");
                return;
            }

            newMovie.Id = lastId + 1;
            using (var writer = new StreamWriter(_filename))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<MovieMap>();
                    csv.WriteRecords(movies);
                }
            }

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
            return new List<Movie>(records);
        }
    }
}