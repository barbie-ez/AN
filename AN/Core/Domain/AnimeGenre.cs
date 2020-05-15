using System;
namespace AN.Core.Domain
{
    public class AnimeGenre
    {
        public AnimeGenre()
        {
        }
        public int AnimeId { get; set; }
        public Anime Anime { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
