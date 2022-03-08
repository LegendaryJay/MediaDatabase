using System;

namespace MediaLibrary.MediaEntities
{
    public abstract class Media
    {
        private string _title;
        public int Id { get; set; }

        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Empty string");
                }
                _title = value;
            }
        }

        public abstract string ToPrettyString();
    }
}