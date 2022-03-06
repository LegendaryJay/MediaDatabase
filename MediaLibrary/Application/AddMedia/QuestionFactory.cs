using System;
using MediaLibrary.Application.AddMedia.Questions;
using MediaLibrary.Infrastructure;

namespace MediaLibrary.Application.AddMedia
{
    public static class QuestionFactory
    {
        public static Questions.Questions GetQuestions(MediaType mediaType)
        {
            return mediaType switch
            {
                MediaType.Movie => new MovieQuestions(),
                MediaType.Show => new ShowQuestions(),
                MediaType.Video => new VideoQuestions(),
                _ => throw new Exception("Incorrect value")
            };

        }
    }
}