using System;
namespace AN.DTO.Get
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age  { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string ExpiresOn { get; set; }
    }
}
