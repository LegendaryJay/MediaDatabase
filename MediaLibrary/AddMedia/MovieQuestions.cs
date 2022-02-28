using System.Collections.Generic;
using System.Linq;
using MediaLibrary.Entities;

namespace MediaLibrary.AddMedia
{
    public class MovieQuestions : Questions
    {
        public MovieQuestions() 
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