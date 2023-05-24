namespace QuickType
{

    public partial class Imdb
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string FullTitle { get; set; }
        public string Type { get; set; }
        public long Year { get; set; }
        public Uri Image { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public long RuntimeMins { get; set; }
        public string RuntimeStr { get; set; }
        public string Plot { get; set; }
        public string PlotLocal { get; set; }
        public bool PlotLocalIsRtl { get; set; }
        public string Awards { get; set; }
        public string Directors { get; set; }
        public CompanyListElement[] DirectorList { get; set; }
        public string Writers { get; set; }
        public CompanyListElement[] WriterList { get; set; }
        public string Stars { get; set; }
        public CompanyListElement[] StarList { get; set; }
        public ActorList[] ActorList { get; set; }
        public object FullCast { get; set; }
        public string Genres { get; set; }
        public CountryListElement[] GenreList { get; set; }
        public string Companies { get; set; }
        public CompanyListElement[] CompanyList { get; set; }
        public string Countries { get; set; }
        public CountryListElement[] CountryList { get; set; }
        public string Languages { get; set; }
        public CountryListElement[] LanguageList { get; set; }
        public string ContentRating { get; set; }
        public string ImDbRating { get; set; }
        public long ImDbRatingVotes { get; set; }
        public long MetacriticRating { get; set; }
        public object Ratings { get; set; }
        public object Wikipedia { get; set; }
        public object Posters { get; set; }
        public object Images { get; set; }
        public object Trailer { get; set; }
        public BoxOffice BoxOffice { get; set; }
        public object Tagline { get; set; }
        public string Keywords { get; set; }
        public string[] KeywordList { get; set; }
        public Similar[] Similars { get; set; }
        public object TvSeriesInfo { get; set; }
        public object TvEpisodeInfo { get; set; }
        public string ErrorMessage { get; set; }
    }

    public partial class ActorList
    {
        public string Id { get; set; }
        public Uri Image { get; set; }
        public string Name { get; set; }
        public string AsCharacter { get; set; }
    }

    public partial class BoxOffice
    {
        public string Budget { get; set; }
        public string OpeningWeekendUsa { get; set; }
        public string GrossUsa { get; set; }
        public string CumulativeWorldwideGross { get; set; }
    }

    public partial class CompanyListElement
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public partial class CountryListElement
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public partial class Similar
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public Uri Image { get; set; }
        public string ImDbRating { get; set; }
    }
}
