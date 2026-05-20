using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasIndex(user => user.Email)
                .IsUnique();

            builder.Property(user => user.PasswordHash)
                .IsRequired();

            builder.Property(user => user.Role)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(user => user.Loans)
                .WithOne(user => user.User)
                .HasForeignKey(user => user.UserId);

            builder.HasMany(user => user.Reservations)
                .WithOne(user => user.User)
                .HasForeignKey(user => user.UserId);


        }
    }
}
