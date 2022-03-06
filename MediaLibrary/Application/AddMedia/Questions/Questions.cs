using System;
using System.Collections.Generic;
using System.Linq;
using MediaLibrary.Domain;
using MediaLibrary.Infrastructure;

namespace MediaLibrary.Application.AddMedia.Questions
{
    public abstract class Questions
    {
        protected static List<Question> QuestionList;
        private MediaType _mediaType; 
        private const string CancelKey = "X";

        protected Questions(MediaType mediaType)
        {
            _mediaType = mediaType;
        }

        protected abstract Media Convert(List<string> inputList);

        private static bool IsExit(string str)
        {
            return string.IsNullOrWhiteSpace(str)
                   || string.Equals(str.Trim(), CancelKey, StringComparison.OrdinalIgnoreCase);
        }

        private static string Input()
        {
            var input = Console.ReadLine();
            return IsExit(input) ? null : input;
        }

        private static string Input(string str)
        {
            Console.WriteLine(str);
            return Input();
        }

        public void AddQuestion(Question question)
        {
            QuestionList.Add(question);
        }
        public void AddQuestion(params Question[] questions)
        {
            QuestionList.AddRange(questions);
        }
        private static string RepeatInput(string str)
        {
            var strList = new List<string>();
            Console.WriteLine(str);
            while (true)
            {
                var input = Input();
                if (input is not null)
                {
                    strList.Add(input);
                }
                else if (strList.Count > 0)
                {
                    return string.Join("|", strList);
                }
                else return null;
            }
        }

        public void Ask()
        {
            var results =
                QuestionList.Select(
                        question => question.IsList ? RepeatInput(question.QuestionString) : Input(question.QuestionString)
                    )
                    .ToList();

            if (!results.ToList().Any(x => x is null))
            {
                var media = Convert(results);
                Console.WriteLine("Writing to file");
                Console.WriteLine(media.ToPrettyString());
                MediaFileIoFactory.GetFileIo(_mediaType).AddMedia(media);
                
            }
            else
            {
                Console.WriteLine("Could Not Validate :(");
            }
        }
    }
}