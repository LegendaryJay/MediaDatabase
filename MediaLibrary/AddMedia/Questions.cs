using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using MediaLibrary.Entities;

namespace MediaLibrary.AddMedia
{
    public abstract class Questions
    {
        protected static List<Question> QuestionList;
        
        private const string CancelKey = "X";


        protected abstract Media Convert(List<string> inputList);

        private static bool IsExit(string str)
        {
            return string.IsNullOrWhiteSpace(str)
                   || string.Equals(str.Trim(), CancelKey, comparisonType: StringComparison.OrdinalIgnoreCase);
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

        public Media Ask()
        {
            var results =
                QuestionList.Select(
                        question => question.IsList ? RepeatInput(question.QuestionString) : Input(question.QuestionString)
                    )
                    .ToList();

            if (!results.ToList().Any(x => x is null)) return Convert(results);
            Console.WriteLine("Could Not Validate :(");
            return null;

        }
    }
}