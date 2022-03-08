using System.Reflection;
using MediaLibrary.MediaEntities;

namespace MediaLibrary.ConsoleMenus.AddMedia.QuestionComponents
{
    public abstract class  QuestionBase
    {
        public string QuestionString { get; protected set; }
        protected PropertyInfo Property;
        public bool IsList { get; protected set;  }

        public abstract void SetValue(Media mediaTarget, string input);
    }
}