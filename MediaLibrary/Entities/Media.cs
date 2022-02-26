namespace MediaLibrary.Entities
{
    public abstract class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public abstract string ToPrettyString();
    }
}