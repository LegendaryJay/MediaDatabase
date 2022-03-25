using System;
using System.Collections.Generic;
using MediaLibrary.ConsoleMenus.Top.MediaMenu.AddMedia.QuestionComponents;
using MediaLibrary.FileInteractions;
using MediaLibrary.MediaEntities;
using MediaLibrary.MediaEntities.MediaEnum;
using static MediaLibrary.ConsoleMenus.Tools.ManualInputTools;

namespace MediaLibrary.ConsoleMenus.Top.MediaMenu.AddMedia
{
    public class Questions<TMedia> : IQuestions
        where TMedia : Media, new()
    {
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

        
    }
}