
using Application.DTOs.LoansDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Models;
using Application.Exceptions;

namespace Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _repository;
        private readonly ICopyRepository _copyRepository;

        public LoanService(ILoanRepository repository, ICopyRepository copyRepository)
        {
            _repository = repository;
            _copyRepository = copyRepository;
        }

        public async Task<LoanResponseDTO?> CreateLoan(CreateLoanDTO loan)
        {
            var availableCopy = await _copyRepository.GetCopyById(loan.CopyId);
            if (availableCopy == null)
            {
                throw new NotFoundException($"La copia con id{loan.CopyId} no se encuentra");
            }
            if (!availableCopy.IsAvailable)
            {
                throw new BaseException("Esta copia no esta disponible", 400);
            }

            var newLoan = new Loan
            {
                UserId = loan.UserId,
                CopyId = availableCopy.Id,
                LoanDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(7),
                Fine = 0
            };

            availableCopy.IsAvailable = false;
            await _copyRepository.UpdateCopy(availableCopy);

            await _repository.CreateLoan(newLoan);

            return new LoanResponseDTO
            {
                Id = newLoan.Id,
                UserId = newLoan.UserId,
                CopyId = newLoan.CopyId,
                LoanDate = newLoan.LoanDate,
                DueDate = newLoan.DueDate,
                ReturnDate = newLoan.ReturnDate,
                Fine = newLoan.Fine
            };

        }

        public async Task<Loan?> GetLoanById(Guid loanId)
        {
            var foundLoan = await _repository.GetLoanById(loanId);

            if (foundLoan == null)
            { 
                throw new NotFoundException($"El préstamo con id {loanId} no existe");
            }

            return foundLoan;
        }
        public async Task<List<Loan>> GetAllLoans()
        {
            return await _repository.GetAllLoans();
        }

        public async Task<List<Loan>> GetLoansByUser(Guid userId)
        {
            var foundLoan = await _repository.GetLoansByUser(userId);
            if(foundLoan == null)
            {
                throw new NotFoundException($"El prestamo con el id de usuario: {userId} no existe");
            }
            return foundLoan;
        }
        public async Task<List<Loan>> GetActiveLoans()
        {
            var activeLoans = await _repository.GetActiveLoans();
            if(activeLoans == null)
            {
                throw new NotFoundException("No hay prestamos activos");
            }

            return activeLoans;
        }
        public async Task<List<Loan>> GetLateLoans()
        {
            var loans = await _repository.GetLateLoans();

            if (!loans.Any())
            {
                throw new NotFoundException("No hay préstamos atrasados");
            }

            return loans;
        }

        public async Task<LoanResponseDTO?> ReturnLoan(Guid loanId)
        {
            var loan = await _repository.GetLoanById(loanId);

            if (loan == null)
                throw new NotFoundException($"El préstamo con id {loanId} no existe");

            if (loan.ReturnDate != null)
                throw new BaseException("Este préstamo ya fue devuelto", 400);

            loan.ReturnDate = DateTime.UtcNow;

            var daysLate = (loan.ReturnDate.Value - loan.DueDate).Days;

            if (daysLate > 0)
            {
                loan.Fine = daysLate * 1000;
            }

            loan.Copy.IsAvailable = true;

            await _repository.UpdateLoan(loan);

            return new LoanResponseDTO
            {
                Id = loan.Id,
                UserId = loan.UserId,
                CopyId = loan.CopyId,
                LoanDate = loan.LoanDate,
                DueDate = loan.DueDate,
                ReturnDate = loan.ReturnDate,
                Fine = loan.Fine
            };
        }
        public async Task<object> GetMostLoanedByCategory()
        {
            var loans = await _repository.GetLoansWithBookCategory();

            var result = loans
                .GroupBy(loan => loan.Copy.Book.Category.Name)
                .Select(categoryGroup => new
                {
                    Category = categoryGroup.Key,
                    TotalLoans = categoryGroup.Count(),
                    MostLoanedBook = categoryGroup
                        .GroupBy(loan => loan.Copy.Book.Title)
                        .OrderByDescending(bookGroup => bookGroup.Count())
                        .Select(bookGroup => bookGroup.Key)
                        .FirstOrDefault()
                })
                .ToList();

            if (!result.Any())
                throw new NotFoundException("No hay datos de préstamos para analizar");

            return result;
        }
    }
}
