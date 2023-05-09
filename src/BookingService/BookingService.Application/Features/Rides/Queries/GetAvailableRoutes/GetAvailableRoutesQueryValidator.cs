using BookingService.Application.Features.Rides.Queries.GeAvailableRoutes;
using FluentValidation;

namespace BookingService.Application.Features.Rides.Queries.GetAvailableRoutes
{
    public class GetAvailableRoutesQueryValidator : AbstractValidator<GetAvailableRoutesQuery>
    {
        public GetAvailableRoutesQueryValidator()
        {
            RuleFor(r => r.From)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(40).WithMessage("{PropertyName} must not exceed 40 characters");

            RuleFor(r => r.To)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(40).WithMessage("{PropertyName} must not exceed 40 characters");

            RuleFor(r => r.NumberOfSeats)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0.");

            RuleFor(r => r.DepartureTime)
                .Must(BeAValidDate).WithMessage("{PropertyName} is required.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
