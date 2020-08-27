using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace AN.DTO.Post
{
    public class CreateAnimeDTO
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public int Rating { get; set; }

        public int NoOfEps { get; set; }

        public int StudioId { get; set; }

        
        public IList<int> AnimeGenre { get; set; } = new List<int>();

        public bool HasManga { get; set; }

        public int Duration { get; set; }

        [Required]
        public IFormFile AnimeIcon { get; set; }

        public string Rated { get; set; }

        public string BraodcastTime { get; set; }

        public IList<int> AnimeRatings { get; set; } = new List<int>();
    }
}