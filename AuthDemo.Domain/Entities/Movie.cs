
using AuthDemo.Domain.Entities;

namespace Library.Models.Domain
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public ICollection<UserMovie> UserMovies { get; set; }

    }
}
