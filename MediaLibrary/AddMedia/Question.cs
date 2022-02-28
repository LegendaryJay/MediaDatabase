namespace MediaLibrary.AddMedia
{
    public class Question
    {
        public readonly string QuestionString;
        public readonly bool IsList;

        public Question(string question, bool isList)
        {
            QuestionString = question;
            IsList = isList;
        }
    }
}