using System;
using System.ComponentModel.DataAnnotations;

namespace AN.DTO.Post
{
    public class CreateRatingDTO
    {
        [Required]
        public int Score { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
