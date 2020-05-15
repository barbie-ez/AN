using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AN.Core.Domain
{
    public class User : IdentityUser
    {
        public User()
        {
        }

        [Required(ErrorMessage ="The firstname field is required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "The lastname field is required")]
        public string Lastname { get; set; }


        [Required(ErrorMessage = "The date of birth field is required")]
        public DateTime DateOfBirth { get; set; }

        public ICollection<Role> Roles { get; set; } = new List<Role>();

        public ICollection<Forum> Forums { get; set; }

        public ICollection<Favorite> Favorites { get; set; }

        public string Token { get; set; }



    }
}
