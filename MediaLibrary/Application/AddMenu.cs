﻿using System;
using MediaLibrary.Application.AddMedia;
using MediaLibrary.Infrastructure;

namespace MediaLibrary.Application
{
    public class AddMenu
    {
        private readonly IQuestions _questions;
        public AddMenu(MediaType mediaType)
        {
            _questions = QuestionsFactory.GetQuestions(mediaType);
        }

        public void Run()
        {
            try
            {
                _questions.Ask();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}