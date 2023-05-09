using BookingService.Application.Exceptions;
using BookingService.Application.Interfaces.Persistence;
using BookingService.Domain.Entities;
using MediatR;

namespace BookingService.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userToDelete = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);

            if (userToDelete == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            await _unitOfWork.UserRepository.DeleteAsync(userToDelete);
        }
    }
}
