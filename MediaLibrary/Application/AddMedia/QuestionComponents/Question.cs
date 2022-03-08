using System;
using System.Linq.Expressions;
using System.Reflection;
using MediaLibrary.Domain;

namespace MediaLibrary.Application.AddMedia.QuestionComponents
{
    public class Question<TMedia,T> : QuestionBase
        where TMedia : Media
    {
        public Question(Expression<Func<TMedia, T>> property)
        {
            Property = (PropertyInfo) ((MemberExpression) property.Body).Member;
            QuestionString = $"{typeof(TMedia).Name} | Input {Property.Name}:";
            IsList = false;
        }


        public override void SetValue(Media mediaTarget, string input)
        {
            Property.SetValue(
                (TMedia) mediaTarget,
                TypeConvert.Convert<string, T>(input)
            );
        }


    }
}