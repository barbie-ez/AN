using System;
namespace AN.Core.Domain
{
    public class AnimeRating
    {
        public AnimeRating()
        {
        }
        public int AnimeId { get; set; }
        public Anime Anime { get; set; }
        public int RatingId { get; set; }
        public Rating Rating { get; set; }
    }
}
