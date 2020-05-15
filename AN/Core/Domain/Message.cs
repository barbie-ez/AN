using System;
namespace AN.Core.Domain
{
    public class Message : Base
    {
        public Message()
        {
        }

        public int ForumId { get; set; }

        public Forum Forum { get; set; }

        public string Chat { get; set; }

        public User Addedby { get; set; }

        public string AddedbyId { get; set; }

    }
}
