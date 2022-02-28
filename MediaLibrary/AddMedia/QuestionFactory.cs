using System;

namespace MediaLibrary.AddMedia
{
    public static class QuestionFactory
    {
        public static Questions Get(int selection)
        {
            return selection switch
            {
                0 => new MovieQuestions(),
                1 => new ShowQuestions(),
                2 => new VideoQuestions(),
                _ => throw new Exception("Incorrect value")
            };
        }
    }
}