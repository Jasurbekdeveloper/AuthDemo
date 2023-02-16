using AuthDemo.Domain.Contants;
using AuthDemo.Domain.Enums;
using Library.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthDemo.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(TableName.Users);

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Username)
            .HasMaxLength(50)
            .IsRequired(true);

        builder.Property(user => user.Password) 
            .HasMaxLength(50)
            .IsRequired(true);

        builder.Property(user => user.EmailAddres)
            .HasMaxLength(50)
            .IsRequired(true);

        builder.HasData(GenerateUsers());

    }


    private List<User> GenerateUsers()
    {
        return new List<User>
        {
            new User
            {
                Id = Guid.Parse("bc56836e-0345-4f01-a883-47f39e32e079"),
                Username = "Jasurbek",
                Role = UserRole.Admin,
                EmailAddres = "Jasurbek@gmail.com",
                Password = "1234"
            },
            new User
            {
                Id = Guid.Parse("96224645-c94c-4994-a15f-753ba0f1200b"),
                Username = "Tohirjon",
                EmailAddres = "Tohir@gmail.com",
                Password = "7379"
            }
        };
    }
}
