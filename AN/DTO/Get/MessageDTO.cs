using System;
namespace AN.DTO.Get
{
    public class MessageDTO
    {
        public int Id { get; set; }

        public string Chat { get; set; }

        public UserDTO Addedby { get; set; }
    }
}
