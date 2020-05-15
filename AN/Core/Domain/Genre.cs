using System;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    public class Genre : Base
    {
        public Genre()
        {
        }
        public string Name { get; set; }

        public ICollection<AnimeGenre> AnimeGenres { get; set; } = new List<AnimeGenre>();
    }
}
