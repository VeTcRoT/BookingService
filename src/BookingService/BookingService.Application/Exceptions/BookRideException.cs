using BookingService.Application.Features.Rides.Commands.BookRide;

namespace BookingService.Application.Exceptions
{
    public class BookRideException : Exception
    {
        public List<string>? BookRideErrors { get; set; }
        public BookRideException() { }
        public BookRideException(string message) : base(message) { }
        public BookRideException(string message, Exception inner) : base(message, inner) { }
        public BookRideException(RideConfirmationDto rideConfirmation)
        {
            BookRideErrors = new List<string>();

            foreach (var bookRideError in rideConfirmation.Errors)
            {
                BookRideErrors.Add(bookRideError);
            }
        }
    }
}
