using System;
using System.Collections.Generic;
using System.Linq;
using MediaLibrary.Entities;

namespace MediaLibrary.AddMedia
{
    public abstract class Questions
    {
        protected static List<Question> QuestionList;
        
        private const string CancelKey = "X";


        protected abstract Media Convert(List<string> inputList);

        private bool IsExit(string str)
        {
            return string.IsNullOrWhiteSpace(str)
                   || string.Equals(str.Trim(), CancelKey, comparisonType: StringComparison.OrdinalIgnoreCase);
        }

        private string Input()
        {
            var input = Console.ReadLine();
            return IsExit(input) ? null : input;
        }

        private string Input(string str)
        {
            Console.WriteLine(str);
            return Input();
        }

        private string RepeatInput(string str)
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
            }
        }

        public Media Ask()
        {
            var results =
                QuestionList.Select(
                        question => question.IsList ? RepeatInput(question.QuestionString) : Input(question.QuestionString)
                    )
                    .ToList();

            return Convert(results);
        }
    }
}