using System;
using System.Collections.Generic;
using System.Linq;
using MediaLibrary.Application.AddMedia.QuestionComponents;
using MediaLibrary.Domain;
using MediaLibrary.Infrastructure;

namespace MediaLibrary.Application.AddMedia
{
    public class Questions<TMedia> : IQuestions
        where TMedia : Media, new()
    {
        private readonly List<QuestionBase> _questionList;
        private readonly MediaType _mediaType;
        private const string CancelKey = "X";

        public Questions(MediaType mediaType, List<QuestionBase> questions)
        {
            _mediaType = mediaType;
            _questionList = questions;
        }

        public Questions(MediaType mediaType, params QuestionBase[] questions) :
            this(mediaType, questions.ToList())
        {
        }

        private static bool IsExit(string str)
        {
            return string.IsNullOrWhiteSpace(str)
                   || string.Equals(str.Trim(), CancelKey, StringComparison.OrdinalIgnoreCase);
        }

        private static string Input()
        {
            return Console.ReadLine();
        }


        public void Ask()
        {
            TMedia media = new();
            foreach (var question in _questionList)
            {
                Console.WriteLine(
                    question.QuestionString
                    + (
                        question.IsList ? $"\n\t Enter \"{CancelKey}\" to Exit" : ""
                    )
                );

                do
                {
                    var input = Input();
                    if (IsExit(input))
                    {
                        break;
                    }

                    question.SetValue(media, input);
                } while (question.IsList);
            }

            Console.WriteLine("Writing to file");
            Console.WriteLine(media.ToPrettyString());
            MediaFileIoFactory.GetFileIo(_mediaType).AddMedia(media);
        }
    }
}