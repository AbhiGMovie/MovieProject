using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public string Location { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string SoundEffects { get; set; }
        public string imdbID { get; set; }
        public string Title { get; set; }
        public Nullable<int> listingType { get; set; }
        public Nullable<double> imdbRating { get; set; }
    }
    public partial class MovieStills
    {
        public int Id { get; set; }
        public Nullable<int> MovieId { get; set; }
        public int StillId { get; set; }
    }
    public partial class Stills
    {
        public int Id { get; set; }
        public string stillURL { get; set; }
    }
    public partial class Users
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
    }

    public partial class booking
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int movieId { get; set; }
        public string location { get; set; }
        public int tickets { get; set; }
    }
    public enum ListingType
    {
        NOW_SHOWING,
        FUTURE,
        OTT,
        COMING_SOON
    }
    public class Movie_Stills
    {
        public int Id { get; set; }
        public Nullable<int> MovieId { get; set; }
        public string StillURL { get; set; }
    }
    public class MovieDetails
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public string Location { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string SoundEffects { get; set; }
        public string imdbID { get; set; }
        public string Title { get; set; }
        public ListingType listingType { get; set; }
        public Nullable<double> imdbRating { get; set; }
        public List<Movie_Stills> stills { get; set; }
    }
}
