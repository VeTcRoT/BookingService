using AutoMapper;
using BookingService.Application.Exceptions;
using BookingService.Application.Interfaces.Services.Infrastructure;
using BookingService.Domain.Entities;
using BookingService.Domain.Interfaces.Repositories;
using MediatR;

namespace BookingService.Application.Features.Rides.Commands.BookRide
{
    public class BookRideCommandHandler : IRequestHandler<BookRideCommand, BookRideDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITicketService _ticketService;
        private readonly IRouteApiService _routeService;
        private readonly IMapper _mapper;

        public BookRideCommandHandler(IUnitOfWork userRepository, IRouteApiService routeService, ITicketService ticketService, IMapper mapper)
        {
            _unitOfWork = userRepository;
            _routeService = routeService;
            _ticketService = ticketService;
            _mapper = mapper;
        }

        public async Task<BookRideDto> Handle(BookRideCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            var validator = new BookRideCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var bookedRide = await _routeService.BookRideAsync(request);

            if (!bookedRide.IsSuccess)
            {
                throw new BookRideException(bookedRide);
            }

            string ticket = await _ticketService.GenerateTicket(request.UserId, bookedRide);

            Ride ride = _mapper.Map<Ride>(bookedRide);
            List<Seat> seats = _mapper.Map<List<Seat>>(bookedRide.Seats);

            ride.Seats = seats;
            ride.TicketCode = ticket;
            ride.UserId = request.UserId;

            await _unitOfWork.RideRepository.AddAsync(ride);

            return new BookRideDto() { TicketCode = ticket };
        }
    }
}
