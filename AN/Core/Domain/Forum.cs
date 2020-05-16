using System;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    public class Forum : Base
    {
        public Forum()
        {
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<Message> Message { get; set; } = new List<Message>();

        public int AnimeId { get; set; }

        public Anime Anime { get; set; }

    }
}
