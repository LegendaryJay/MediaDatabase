using System;

namespace MediaLibrary.Menu.Core
{
    public class OpenQuestionTuple : MenuStructureTools
    {
        private readonly Func<string, bool> _validator;
        public readonly bool IsList;
        public readonly string Question;

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