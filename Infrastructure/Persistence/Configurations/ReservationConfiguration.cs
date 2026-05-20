using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Infrastructure.Persistence.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(reservation => reservation.Id);

            builder.Property(reservation => reservation.ReservationDate)
                .IsRequired();

            builder.HasOne(reservation => reservation.User)
                .WithMany(reservation => reservation.Reservations)
                .HasForeignKey(reservation => reservation.UserId);

            builder.HasOne(reservation => reservation.Book)
                .WithMany(reservation => reservation.Reservations)
                .HasForeignKey(reservation => reservation.BookId);
        }
    }
}
