using BookingService.Application.Interfaces.Persistence;
using FluentValidation;
using FluentValidation.Validators;

namespace BookingService.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(30).WithMessage("{PropertyName} must not exceed 30 characters.");

            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(30).WithMessage("{PropertyName} must not exceed 30 characters.");

            RuleFor(u => u.Email)
                .MustAsync(EmailExists).WithMessage("{PropertyName} already exists.")
                .EmailAddress().WithMessage("{PropertyName} entered in wrong format.");

            RuleFor(u => u.Password)
                .MinimumLength(8).WithMessage("{PropertyName} length should be greater or equals to 8.");

            RuleFor(u => u.BirthDate)
                .Must(BeAValidDate).WithMessage("{PropertyName} is required.");
        }
        private async Task<bool> EmailExists(string email, CancellationToken cancellationToken)
        {
            return await _userRepository.EmailAlreadyExists(email);
        }
        private bool BeAValidDate(DateOnly date)
        {
            return !date.Equals(default(DateOnly));
        }
    }
}
