namespace BookingService.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() { }
        public NotFoundException(string name, object key)
           : base($"{name} ({key}) is not found") { }
        public NotFoundException(string name, object key, Exception inner) : base($"{name} ({key}) is not found", inner) { }
    }
}
