using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AN.DTO.Post
{
    public class CreateAnimeDTO
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public int NoOfEps { get; set; }

        public int? StudioId { get; set; }

        [Required]
        public IList<int> AnimeGenres { get; set; } = new List<int>();

        public bool HasManga { get; set; }

        public int Duration { get; set; }

        public string Rated { get; set; }

        public DateTime BraodcastTime { get; set; }

        public IList<int> Ratings { get; set; } = new List<int>();
    }
}