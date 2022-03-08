using System;
using System.Collections.Generic;
using MediaLibrary.ConsoleMenus.AddMedia.QuestionComponents;
using MediaLibrary.FileInteractions;
using MediaLibrary.MediaEntities;
using MediaLibrary.MediaEntities.MediaEnum;

namespace MediaLibrary.ConsoleMenus.AddMedia
{
    public class Questions<TMedia> : IQuestions
        where TMedia : Media, new()
    {
        private const string CancelKey = "X";
        private readonly MediaType _mediaType;
        private readonly List<QuestionBase> _questionList;

        public Questions(MediaType mediaType, List<QuestionBase> questions)
        {
            _mediaType = mediaType;
            _questionList = questions;
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
                    if (IsExit(input)) break;

                    question.SetValue(media, input);
                } while (question.IsList);
            }

            Console.WriteLine("Writing to file");
            Console.WriteLine(media.ToPrettyString());
            MediaFileIoFactory.GetFileIo(_mediaType).AddMedia(media);
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
    }
}