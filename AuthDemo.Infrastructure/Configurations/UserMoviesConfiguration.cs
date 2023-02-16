using AuthDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace AuthDemo.Infrastructure.Configurations;

public class UserMoviesConfiguration : IEntityTypeConfiguration<UserMovie>
{
    public void Configure(EntityTypeBuilder<UserMovie> builder)
    {
        builder.HasKey(userMovie => new 
            { userMovie.MovieId, userMovie.UserId });

        builder.HasOne(um => um.User)
            .WithMany(u => u.UserMovies)
            .HasForeignKey(u => u.UserId);

        builder.HasOne(um => um.Movie)
            .WithMany(m => m.UserMovies)
            .HasForeignKey(m => m.MovieId);

    }
}
