

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(loan => loan.Id);

            builder.Property(loan => loan.LoanDate)
                .IsRequired();

            builder.Property(loan => loan.DueDate)
                .IsRequired();

            builder.HasOne(loan => loan.User)
                .WithMany(loan => loan.Loans)
                .HasForeignKey(loan => loan.UserId);

            builder.HasOne(loan => loan.Copy)
                .WithMany(loan => loan.Loans)
                .HasForeignKey(loan => loan.CopyId);

        }
    }
}
