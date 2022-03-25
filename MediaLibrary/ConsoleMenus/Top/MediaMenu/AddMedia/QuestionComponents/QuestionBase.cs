using System.Reflection;
using MediaLibrary.MediaEntities;

namespace MediaLibrary.ConsoleMenus.Top.MediaMenu.AddMedia.QuestionComponents
{
    public abstract class QuestionBase
    {
        protected PropertyInfo Property;
        public string QuestionString { get; protected set; }
        public bool IsList { get; protected set; }

        public abstract void SetValue(Media mediaTarget, string input);
    }
}