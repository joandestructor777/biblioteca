using Application.DTOs.LoansDTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Application.Exceptions;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _service;
        public LoanController(ILoanService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLoan(CreateLoanDTO loan)
        {
            try
            {
                var createdLoan = await _service.CreateLoan(loan);

                return Ok(createdLoan);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpGet("{loanId}")]
        public async Task<IActionResult> GetLoanById(Guid loanId)
        {
            try
            {
                var foundLoan = await _service.GetLoanById(loanId);

                return Ok(foundLoan);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoans()
        {
            try
            {
                var loans = await _service.GetAllLoans();

                return Ok(loans);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetLoansByUser(Guid userId)
        {
            try
            {
                var loans = await _service.GetLoansByUser(userId);

                return Ok(loans);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveLoans()
        {
            try
            {
                var loans = await _service.GetActiveLoans();

                return Ok(loans);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpGet("late")]
        public async Task<IActionResult> GetLateLoans()
        {
            try
            {
                var loans = await _service.GetLateLoans();

                return Ok(loans);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpPost("return/{loanId}")]
        public async Task<IActionResult> ReturnLoan(Guid loanId)
        {
            try
            {
                var result = await _service.ReturnLoan(loanId);
                return Ok(result);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpGet("stats/most-loaned-by-category")]
        public async Task<IActionResult> GetMostLoanedByCategory()
        {
            try
            {
                var result = await _service.GetMostLoanedByCategory();
                return Ok(result);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new
                {
                    message = ex.Message
                });
            }
        }
    }
}