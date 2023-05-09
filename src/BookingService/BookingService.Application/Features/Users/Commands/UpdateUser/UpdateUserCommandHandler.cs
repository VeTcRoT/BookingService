using AutoMapper;
using BookingService.Application.Exceptions;
using BookingService.Application.Interfaces.Persistence;
using BookingService.Domain.Entities;
using MediatR;

namespace BookingService.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);

            if (userToUpdate == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            var validator = new UpdateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, userToUpdate, typeof(UpdateUserCommand), typeof(User));

            await _unitOfWork.UserRepository.UpdateAsync(userToUpdate);
        }
    }
}
