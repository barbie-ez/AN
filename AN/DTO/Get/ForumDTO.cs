using System;
using System.Collections.Generic;

namespace AN.DTO.Get
{
    public class ForumDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IList<MessageDTO> Message { get; set; } = new List<MessageDTO>();

        public AnimeDTO Anime { get; set; }
    }
}
