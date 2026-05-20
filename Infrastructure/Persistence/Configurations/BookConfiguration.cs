using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(book => book.Id);

            builder.Property(book => book.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(book => book.ISBN)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(book => book.PublicationYear)
                .IsRequired();

            builder.HasOne(book => book.Category)
                .WithMany(book => book.Books)
                .HasForeignKey(book => book.CategoryId);
        }
    }
}