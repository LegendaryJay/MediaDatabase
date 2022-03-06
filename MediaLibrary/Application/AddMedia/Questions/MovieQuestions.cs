using System.Collections.Generic;
using System.Linq;
using MediaLibrary.Domain;
using MediaLibrary.Infrastructure;

namespace MediaLibrary.Application.AddMedia.Questions
{
    public class MovieQuestions : Questions
    {
        public MovieQuestions() : base(MediaType.Movie)
        {
            QuestionList = new List<Question>
            {
                new("What Movie do you want to add?", false),
                new("What Genres does this movie include??", true)
            };
        }

        protected override Media Convert(List<string> inputList)
        {
            return new Movie
            {
                Title = inputList[0],
                Genres = inputList[1].Split('|').ToList()
            };
        }
        
    }
}