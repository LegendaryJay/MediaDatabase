﻿using System;
using System.Collections.Generic;
using MediaLibrary.Application.AddMedia.MediaEnum;
using MediaLibrary.Application.AddMedia.QuestionComponents;
using MediaLibrary.Domain;
using MediaLibrary.Infrastructure;

namespace MediaLibrary.Application.AddMedia
{
    public static class QuestionsFactory
    {
        public static IQuestions GetQuestions(MediaType mediaType)
        {
            return mediaType switch
            {
                MediaType.Movie => new Questions<Movie>(mediaType,
                    new List<QuestionBase>
                    {
                        new Question<Movie, string>( m => m.Title), 
                        new QuestionList<Movie, string>( m => m.Genres)
                    }),
                MediaType.Show => new Questions<Show>(mediaType,
                    new List<QuestionBase>
                    {
                        new Question<Show, string>(m => m.Title),
                        new Question<Show, int>( m => m.Episodes),
                        new Question<Show, int>(m => m.Seasons),
                        new Question<Show, List<string>>(m => m.Writers)
                    }),
                MediaType.Video => new Questions<Video>(mediaType,
                    new List<QuestionBase>
                    {
                        new Question<Video, string>(m => m.Title),
                        new Question<Video, string>( m => m.Format),
                        new QuestionList<Video, int>( m => m.Regions)
                    }),
                _ => throw new ArgumentOutOfRangeException(nameof(mediaType))
            };
        }
    }
}