using System;
namespace AN.Core.Domain
{
    public class Favorite : Base
    {
        public Favorite()
        {
        }

        public Anime Anime { get; set; }
        public int AnimeId { get; set; }
    }
}
