using System;
using System.Collections.Generic;
using System.Linq;
using MediaLibrary.Domain;
using MediaLibrary.Infrastructure;

namespace MediaLibrary.Application.AddMedia.Questions
{
    public class VideoQuestions : Questions
    {
        public VideoQuestions() : base(MediaType.Video)
        {
            QuestionList = new List<Question>
            {
                new("What Video do you want to add?", false),
                new("What Format is it in?", false),
                new("What regions is it for?", true)
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