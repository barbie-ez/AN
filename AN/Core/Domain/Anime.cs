using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace AN.Core.Domain
{
    public class Anime : Base
    {
        public Anime()
        {
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public int NoOfEps { get; set; }

        public int? StudioId { get; set; }

        public Studio Studio { get; set; }

        public string AnimeIcon { get; set; }

        //public ICollection<AnimeGenre> AnimeGenres { get; set; } = new List<AnimeGenre>();

        public ICollection<Genre> Genres { get; set; } = new List<Genre>();

        public bool HasManga { get; set; }

        public int Duration { get; set; }

        public string Rated { get; set; } 

        public DateTime BraodcastTime { get; set; }

        //public ICollection<AnimeRating> AnimeRating { get; set; } = new List<AnimeRating>();

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
