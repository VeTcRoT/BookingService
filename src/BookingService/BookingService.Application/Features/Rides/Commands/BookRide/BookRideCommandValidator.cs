using FluentValidation;

namespace BookingService.Application.Features.Rides.Commands.BookRide
{
    public class BookRideCommandValidator : AbstractValidator<BookRideCommand>
    {
        public BookRideCommandValidator()
        {
            RuleFor(r => r.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(r => r.RouteId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(r => r.NumberOfSeats)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0.")
                .LessThanOrEqualTo(5).WithMessage("{PropertyName} should not exceed 5 seats.");
        }
    }
}
