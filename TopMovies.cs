namespace QuickType
{

    public partial class TopMovies
    {
        public Item[] Items { get; set; }
        public string ErrorMessage { get; set; }
    }

    public partial class Item
    {
        public string Id { get; set; }
        public long Rank { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public long Year { get; set; }
        public Uri Image { get; set; }
        public string Crew { get; set; }
        public string ImDbRating { get; set; }
        public long ImDbRatingCount { get; set; }
    }
}

