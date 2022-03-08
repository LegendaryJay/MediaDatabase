using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using MediaLibrary.Domain;

namespace MediaLibrary.Application.AddMedia.QuestionComponents
{
    public class QuestionList<TMedia, T> : QuestionBase 
        where TMedia : Media
    {
        private readonly List<T> _returnList;
        public QuestionList( Expression<Func<TMedia, List<T>>> property)
        {
            Property = (PropertyInfo)((MemberExpression) property.Body).Member;
            QuestionString = $"{typeof(TMedia).Name} | Input List of {Property.Name}:";
            _returnList = new List<T>();
            IsList = true;
        }
        
        public override void SetValue(Media mediaTarget, string input)
        {
            _returnList.Add(
                TypeConvert.Convert<string, T>(input)
                );
            Property.SetValue( (TMedia) mediaTarget, _returnList, null);
        }
        
    }
}