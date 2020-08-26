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

        //public ICollection<Anime> Animes { get; set; } = new List<Anime>();
    }
}
