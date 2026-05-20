using Application.DTOs.ReservationsDTOs;
using Application.Exceptions;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _service;

        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDTO dto)
        {
            try
            {
                var reservation = await _service.CreateReservation(dto);

                return Ok(reservation);
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
        public async Task<IActionResult> GetAllReservations()
        {
            try
            {
                var reservations = await _service.GetAllReservations();

                return Ok(reservations);
            }
            catch (BaseException ex)
            {
                return StatusCode(ex.StatusCode, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpGet("{reservationId}")]
        public async Task<IActionResult> GetReservationById(Guid reservationId)
        {
            try
            {
                var reservation = await _service.GetReservationById(reservationId);

                return Ok(reservation);
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