using AutoMapper;
using BookingService.Application.Exceptions;
using BookingService.Application.Interfaces.Persistence;
using BookingService.Domain.Entities;
using MediatR;

namespace BookingService.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHash _passwordHash;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHash passwordHash)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHash = passwordHash;
        }

        public async Task<CreateUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserCommandValidator(_unitOfWork.UserRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var mappedUser = _mapper.Map<User>(request);

            var passwordHash = _passwordHash.HashPassword(request.Password, out byte[] salt);

            mappedUser.PasswordSalt = Convert.ToHexString(salt);
            mappedUser.PasswordHash = passwordHash;

            var user = await _unitOfWork.UserRepository.AddAsync(mappedUser);

            var userToReturn = _mapper.Map<CreateUserDto>(user);
            userToReturn.Password = request.Password;

            return userToReturn;
        }
    }
}
