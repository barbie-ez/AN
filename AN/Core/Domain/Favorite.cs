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
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
