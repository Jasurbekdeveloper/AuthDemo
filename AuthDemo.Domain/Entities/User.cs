using AuthDemo.Domain.Entities;
using AuthDemo.Domain.Enums;
    
namespace Library.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddres { get; set; }
        public UserRole? Role { get; set; } = UserRole.User;
        public ICollection<UserMovie> UserMovies { get; set; }

    }
}
