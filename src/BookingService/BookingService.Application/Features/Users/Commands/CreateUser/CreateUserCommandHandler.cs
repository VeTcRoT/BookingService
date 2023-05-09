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

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserCommandValidator(_unitOfWork.UserRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var user = await _unitOfWork.UserRepository.AddAsync(_mapper.Map<User>(request));

            return _mapper.Map<CreateUserDto>(user);
        }
    }
}
