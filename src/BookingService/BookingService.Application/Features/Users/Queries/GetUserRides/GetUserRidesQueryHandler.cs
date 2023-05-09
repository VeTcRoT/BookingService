using AutoMapper;
using BookingService.Application.Exceptions;
using BookingService.Application.Interfaces.Persistence;
using MediatR;

namespace BookingService.Application.Features.Users.Queries.GetUserRides
{
    public class GetUserRidesQueryHandler : IRequestHandler<GetUserRidesQuery, List<UserRideDto>?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserRidesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UserRideDto>?> Handle(GetUserRidesQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                throw new NotFoundException(nameof(user), request.UserId);
            }

            var userRides = await _unitOfWork.UserRepository.GetUserRidesAsync(request.UserId);

            return _mapper.Map<List<UserRideDto>>(userRides);
        }
    }
}
