﻿using System;
namespace AN.Core.Domain
{
    public class Rating
    {
        public Rating()
        {
        }
        public int Score { get; set; }

        public int AnimeId { get; set; }

        public Anime Anime { get; set; }
    }
}
