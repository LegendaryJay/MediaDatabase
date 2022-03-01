using MediaLibrary.AddMedia;
using MediaLibrary.IO;

namespace MediaLibrary.SimpleMenu
{
    public class AddMenu
    {
        private readonly MediaFileIo _fileIo;
        private readonly Questions _questions;
        public AddMenu(MediaFileIo fileIo)
        {
            _fileIo = fileIo;
            _questions = QuestionFactory.Get(fileIo.Index);
        }

        public void Run()
        {
            _fileIo.AddMedia(_questions.Ask());
            
        }
    }
}