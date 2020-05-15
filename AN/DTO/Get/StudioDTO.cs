using System;
using System.Collections.Generic;

namespace AN.DTO.Get
{
    public class StudioDTO
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public IList<AnimeDTO> Animes { get; set; } = new List<AnimeDTO>();
    }
}
