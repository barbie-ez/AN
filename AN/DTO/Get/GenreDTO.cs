using System;
using System.Collections.Generic;

namespace AN.DTO.Get
{
    public class GenreDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<AnimeDTO> AnimeGenres { get; set; } = new List<AnimeDTO>();
    }
}
