namespace QuickType
{

    public partial class SearchMovieC
    {
        public SearchTypeEnum SearchType { get; set; }
        public string Expression { get; set; }
        public Result[] Results { get; set; }
        public string ErrorMessage { get; set; }
    }

    public partial class Result
    {
        public string Id { get; set; }
        public SearchTypeEnum ResultType { get; set; }
        public Uri Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public enum SearchTypeEnum { Title };
}
