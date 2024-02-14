using API.Entities;

namespace API.Dto
{
    public record UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime LastActive { get; set; }
        public DateTime Created { get; set; }

        public List<PhotoDto> Photos { get; set; }
    }
}