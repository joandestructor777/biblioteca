

using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class CopyConfiguration : IEntityTypeConfiguration<Copy>
    {
        public void Configure(EntityTypeBuilder<Copy> builder)
        {
            builder.HasKey(copy => copy.Id);

            builder.Property(copy => copy.IsAvailable)
                .IsRequired();

            builder.HasOne(copy => copy.Book)
                .WithMany(copy => copy.Copies)
                .HasForeignKey(copy => copy.BookId)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
