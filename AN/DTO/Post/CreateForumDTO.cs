using System;
using System.Collections.Generic;

namespace AN.DTO.Post
{
    public class CreateForumDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public IList<int> Message { get; set; } = new List<int>();

        public int AnimeId { get; set; }
    }
}
