using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace AN.DTO.Get
{
    public class AnimeDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public int NoOfEps { get; set; }

        public StudioDTO Studio { get; set; }

        public string AnimeIcon { get; set; }

        //public IFormFile AnimeIconPic { get; set; }

        public ICollection<GenreDTO> AnimeGenres { get; set; } = new List<GenreDTO>();

        public bool HasManga { get; set; }

        public int Duration { get; set; }

        public string Rated { get; set; }

        public DateTime BraodcastTime { get; set; }

        public ICollection<RatingDTO> Ratings { get; set; } = new List<RatingDTO>();
    }
}
