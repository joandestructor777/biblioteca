using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface ILoanRepository
    {
        Task<Loan?> CreateLoan(Loan loan);

        Task<Loan?> GetLoanById(Guid loanId);

        Task<List<Loan>> GetAllLoans();

        Task<List<Loan>> GetLoansByUser(Guid userId);

        Task<List<Loan>> GetActiveLoans();

        Task<List<Loan>> GetLateLoans();

        Task<Loan?> UpdateLoan(Loan loan);

        Task<List<Loan>> GetLoansWithBookCategory();
    }
}