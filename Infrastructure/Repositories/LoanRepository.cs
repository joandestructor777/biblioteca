
using Application.Interfaces.Repositories;
using Infrastructure.Persistence;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext _context;

        public LoanRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Loan?> CreateLoan(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
            return loan;
        }

        public async Task<Loan?> GetLoanById(Guid loanId)
        {
            var foundLoan = await _context.Loans
                .Include(loan => loan.User)
                .Include(loan => loan.Copy)
                .FirstOrDefaultAsync(loan => loan.Id == loanId);

            if (foundLoan == null) return null;
            return foundLoan;
        }

        public async Task<List<Loan>> GetAllLoans()
        {
            return await _context.Loans.ToListAsync();
            
        }

        public async Task<List<Loan>> GetLoansByUser(Guid userId)
        {
            return await _context.Loans
                .Where(loan => loan.UserId == userId)
                .Include(loan => loan.User)
                .Include(loan => loan.Copy)
                .ToListAsync();
        }

        public async Task<List<Loan>> GetActiveLoans()
        {
            return await _context.Loans
                .Where(loan => loan.ReturnDate == null)
                .Include(loan => loan.User)
                .Include(loan => loan.Copy)
                .ToListAsync();
        }

        public async Task<List<Loan>> GetLateLoans()
        {
            return await _context.Loans
                .Where(loan =>
                    loan.ReturnDate == null &&
                    loan.DueDate < DateTime.UtcNow)
                .Include(loan => loan.User)
                .Include(loan => loan.Copy)
                .ToListAsync();
        }

        public async Task<Loan?> UpdateLoan(Loan loan)
        {
            var foundLoan = await _context.Loans
                .Include(x => x.Copy)
                .FirstOrDefaultAsync(x => x.Id == loan.Id);

            if (foundLoan == null) return null;

            foundLoan.ReturnDate = loan.ReturnDate;
            foundLoan.Fine = loan.Fine;
            foundLoan.Copy.IsAvailable = loan.Copy.IsAvailable;

            await _context.SaveChangesAsync();

            return foundLoan;
        }
        public async Task<List<Loan>> GetLoansWithBookCategory()
        {
            return await _context.Loans
                .Include(x => x.Copy)
                    .ThenInclude(x => x.Book)
                        .ThenInclude(x => x.Category)
                .ToListAsync();
        }

    }
}
