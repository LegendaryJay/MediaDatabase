using System;
using MediaLibrary.Application.AddMedia;
using MediaLibrary.Application.AddMedia.Questions;
using MediaLibrary.Infrastructure;

namespace MediaLibrary.Application
{
    public class AddMenu
    {
        private readonly Questions _questions;
        public AddMenu(MediaType mediaType)
        {
            _questions = QuestionFactory.GetQuestions(mediaType);
        }

        public void Run()
        {
             _questions.Ask();
            Console.ReadLine();


        }
    }
}