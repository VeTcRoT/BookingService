using AutoMapper;
using BookingService.Application.Features.Rides.Commands.BookRide;
using BookingService.Application.Features.Users.Commands.CreateUser;
using BookingService.Application.Features.Users.Commands.UpdateUser;
using BookingService.Application.Features.Users.Queries.GetUserById;
using BookingService.Application.Features.Users.Queries.GetUserRides;
using BookingService.Domain.Entities;

namespace BookingService.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserDto>();
            CreateMap<Ride, UserRideDto>();

            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();

            CreateMap<User, UpdateUserCommand>().ReverseMap();

            CreateMap<RideConfirmationDto, Ride>();
            CreateMap<SeatDto, Seat>().ForMember(x => x.SeatId, y => y.Ignore());
        }
    }
}
