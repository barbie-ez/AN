using System;
using AN.Core.Repositories;

namespace AN.Core.Domain
{
    public class Base : IEntityBase
    {
        public Base()
        {
            DateCreated = DateUpdated = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
