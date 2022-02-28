using System;
using System.Collections.Generic;
using System.Linq;
using MediaLibrary.Entities;

namespace MediaLibrary.AddMedia
{
    public class VideoQuestions : Questions
    {
        public VideoQuestions()
        {
            QuestionList = new List<Question>
            {
                new("What Movie do you want to add?", false),
                new("What Genres does this movie include??", true)
            };
        }

        protected override Media Convert(List<string> inputList)
        {
            List<int> regionList;
            try
            {
                regionList =
                    inputList[2]
                        .Split('|')
                        .ToList()
                        .Select(x =>
                            {
                                if (int.TryParse(x, out var value))
                                {
                                    return value;
                                }
                                throw new FormatException();
                            }
                        ).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
            return new Video
                {
                    Title = inputList[0],
                    Format = inputList[1],
                    Regions = regionList
                };
        }
    }
}