using Application.DTOs.ReservationsDTOs;
using FluentValidation;

namespace Application.Validators.Reservation
{
    public class CreateReservationValidator : AbstractValidator<CreateReservationDTO>
    {
        public CreateReservationValidator()
        {
            RuleFor(reservation => reservation.UserId)
                .NotEmpty()
                .WithMessage("El UserId es obligatorio");

            RuleFor(reservation => reservation.BookId)
                .NotEmpty()
                .WithMessage("El BookId es obligatorio");
        }
    }
}