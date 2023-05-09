using FluentValidation;

namespace BookingService.Application.Features.Rides.Commands.BookRide
{
    public class BookRideQueryValidator : AbstractValidator<BookRideQuery>
    {
        public BookRideQueryValidator()
        {
            RuleFor(r => r.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(r => r.RouteId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(r => r.NumberOfSeats)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0.");
        }
    }
}
