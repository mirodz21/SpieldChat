using API.Entities;

namespace API.Dto
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? FullName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }

}
