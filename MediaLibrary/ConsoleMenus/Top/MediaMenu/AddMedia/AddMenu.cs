using System;
using MediaLibrary.MediaEntities.MediaEnum;

namespace MediaLibrary.ConsoleMenus.Top.MediaMenu.AddMedia
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
            catch (Exception)
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