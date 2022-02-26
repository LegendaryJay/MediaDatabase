using System;
using Xunit.Sdk;

namespace MediaLibrary.Menu.Core
{
    public class OpenQuestionTuple : MenuStructureTools
    {
        public readonly string Question;
        public readonly bool IsList;
        private readonly Func<string, bool> _validator;

        public OpenQuestionTuple(string question, bool isList, Func<string, bool> validator)
        {
            Question = question;
            IsList = isList;
            _validator = validator;
        }

        public bool Validate(string str)
        {
            return _validator(str);
        }
    }
}