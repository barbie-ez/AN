using System;
using System.Collections.Generic;

namespace AN.Core.Domain
{
    public class Rating : Base
    {
        public Rating()
        {
        }
        public int Score { get; set; }

        //public ICollection<AnimeRating> AnimeRating { get; set; }

        //public string UserId { get; set; }

        //public User User { get; set; }

    }
}

