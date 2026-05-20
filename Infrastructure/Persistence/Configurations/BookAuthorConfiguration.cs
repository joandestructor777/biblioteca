using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations
{
    public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
                builder.HasKey(book => new { book.BookId, book.AuthorId });

                builder.HasOne(book => book.Book)
                    .WithMany(book => book.BookAuthors)
                    .HasForeignKey(book => book.BookId);

                builder.HasOne(book => book.Author)
                    .WithMany(book => book.BookAuthors)
                    .HasForeignKey(book => book.AuthorId);
        }
    }
}
