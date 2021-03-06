﻿using System;
namespace AN.Core.Repositories
{
    public interface IEntityBase
    {
        int Id { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateUpdated { get; set; }
    }
}
