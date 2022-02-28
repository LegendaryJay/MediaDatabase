using System.Collections.Generic;
using MediaLibrary.Entities;

namespace MediaLibrary.AddMedia
{
    public class ShowQuestions : Questions
    {
        public ShowQuestions()
        {
            QuestionList = new List<Question>
            {
                new("What show do you want to add?", false),
                new("How many seasons does it have?", false),
                new("How many episodes does it have?", false),
                new("Who are the writers?", true)
            };
        }

        protected override Media Convert(List<string> inputList)
        {
            return (
                !int.TryParse(inputList[1], out var season) ||
                !int.TryParse(inputList[2], out var episodes)
            )
                ? null
                : new Show()
                {
                    Title = inputList[0],
                    Seasons = season,
                    Episodes = episodes,
                    Writers = inputList[3].Split('|')
                };
        }
    }
}