using System;
namespace AN.DTO.Post
{
    public class CreateMessageDTO
    {
        public int ForumId { get; set; }

        public string Chat { get; set; }

        public string AddedbyId { get; set; }
    }
}
