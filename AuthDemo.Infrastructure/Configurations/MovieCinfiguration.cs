using AuthDemo.Domain.Contants;
using AuthDemo.Domain.Enums;
using Library.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthDemo.Infrastructure.Configurations;

public class MovieCinfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable(TableName.Movies);

        builder.HasKey(movie => movie.Id);

        builder.Property(movie => movie.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(movie => movie.Description)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(movie => movie.Rating) 
            .IsRequired();

        builder.HasData(GenerateMovies());
    }

    private List<Movie> GenerateMovies()
    {
        return new List<Movie>
        {
            new Movie
            {
                Id = Guid.Parse("96224645-c94c-4994-a15f-753ba0f1200a"),
                Title = "Vatan Tuyg'usi!",
                Description = "har bir inson vatanini sevishi lozim.",
                Rating = 123
            }
        };
    }
}
