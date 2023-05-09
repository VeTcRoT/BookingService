using BookingService.Application.Exceptions;
using BookingService.Application.Features.Rides.Queries.GetAvailableRoutes;
using BookingService.Application.Interfaces.Infrastructure;
using MediatR;

namespace BookingService.Application.Features.Rides.Queries.GeAvailableRoutes
{
    public class GetAvailableRoutesQueryHandler : IRequestHandler<GetAvailableRoutesQuery, IEnumerable<RouteDto>?>
    {
        private readonly IRouteApiService _routeService;

        public GetAvailableRoutesQueryHandler(IRouteApiService routeService)
        {
            _routeService = routeService;
        }

        public async Task<IEnumerable<RouteDto>?> Handle(GetAvailableRoutesQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAvailableRoutesQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            return await _routeService.GetAvailableRoutesAsync(request);
        }
    }
}
