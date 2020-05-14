using System;
using Microsoft.AspNetCore.Identity;

namespace AN.Core.Domain
{
    public class Role : IdentityRole
    {
        public Role()
        {
        }

        public Role(string rolename)
        {
            Name = NormalizedName = rolename;
        }

        public string Description { get; set; }

       
    }
}
