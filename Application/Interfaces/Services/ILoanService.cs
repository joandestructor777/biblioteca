using Application.DTOs.LoansDTOs;
using Domain.Models;

namespace Application.Interfaces.Services
{
    public interface ILoanService
    {
        Task<LoanResponseDTO?> CreateLoan(CreateLoanDTO loan);

        Task<LoanResponseDTO?> ReturnLoan(Guid loanId);

        Task<Loan?> GetLoanById(Guid loanId);

        Task<List<Loan>> GetAllLoans();

        Task<List<Loan>> GetLoansByUser(Guid userId);

        Task<List<Loan>> GetActiveLoans();

        Task<List<Loan>> GetLateLoans();

        Task<object> GetMostLoanedByCategory();
    }
}