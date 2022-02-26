using System.CodeDom;
using System.Runtime.InteropServices;
using MediaLibrary.IO;
using MediaLibrary.Menu.Core;

namespace MediaLibrary.Menu.Menus
{
    public class TopMenu : MenuTypes
    {
        private void MovieMenu()
        {
            var mediaMenu = new MediaMenu(
                new MovieFileIo(),
                new OpenQuestionTuple[]
                {
                    new(
                        "What is the name?",
                        false,
                        x => x.Length > 1
                    ),
                    new(
                        "What genres is it?",
                        true,
                        x => x.Length > 1
                    )
                }
            );
            mediaMenu.Run();
        }

        private void ShowMenu()
        {
            var mediaMenu = new MediaMenu(
                new ShowFileIo(),
                new OpenQuestionTuple[]
                {
                    new OpenQuestionTuple(
                        "What is the name?",
                        false,
                        x => x.Length > 1
                    ),
                    new OpenQuestionTuple(
                        "How many seasons?",
                        false,
                        x =>
                        {
                            int.TryParse(x, out var tempint);
                            return tempint > 0;
                        }),
                    new OpenQuestionTuple(
                        "How many episodes?",
                        false,
                        x =>
                        {
                            int.TryParse(x, out var tempint);
                            return tempint > 0;
                        }
                    ),
                    new OpenQuestionTuple(
                        "Who are the writers?",
                        true,
                        x => x.Length > 1
                    )
                }
            );
            mediaMenu.Run();
        }

        private void VideoMenu()
        {
            var mediaMenu = new MediaMenu(
                new VideoFileIo(),
                new OpenQuestionTuple[]
                {
                    new OpenQuestionTuple(
                        " format",
                        false,
                        x => x.Length > 0
                    ),
                    new OpenQuestionTuple(
                        " regions",
                        false,
                        x => x.Length > 0
                    ),
                }
            );
            mediaMenu.Run();
        }

        public void Run()
        {
            MultipleChoiceTypeMenu(
                "Welcome! What do you want to look at?!",
                new CommandTuple("Movies", MovieMenu),
                new CommandTuple("Shows", ShowMenu),
                new CommandTuple("Video", VideoMenu)
            );
        }
    }
}