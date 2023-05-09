using BookingService.Application.Interfaces.Persistence;
using FluentValidation;

namespace BookingService.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(30).WithMessage("{PropertyName} must not exceed 30 characters.");

            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(30).WithMessage("{PropertyName} must not exceed 30 characters.");

            RuleFor(u => u.Email)
                .EmailAddress().WithMessage("{PropertyName} entered in wrong format.");

            RuleFor(u => u.Password)
                .MinimumLength(8).WithMessage("{PropertyName} length should be greater or equals to 8.");

            RuleFor(u => u.BirthDate)
                .Must(BeAValidDate).WithMessage("{PropertyName} is required.");
        }
        private bool BeAValidDate(DateOnly date)
        {
            return !date.Equals(default(DateOnly));
        }
    }
}
