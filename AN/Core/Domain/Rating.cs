using System;
namespace AN.Core.Domain
{
    public class Rating : Base
    {
        public Rating()
        {
        }
        public int Score { get; set; }

        public int AnimeId { get; set; }

        public Anime Anime { get; set; }

        public int UserId { get; set; }

        public int User { get; set; }
    }
}

