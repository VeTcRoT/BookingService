using AutoMapper;
using BookingService.Application.Exceptions;
using BookingService.Domain.Dtos;
using BookingService.Domain.Entities;
using BookingService.Domain.Interfaces.Repositories;
using MediatR;

namespace BookingService.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}
