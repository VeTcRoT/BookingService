namespace BookingService.Application.Interfaces.Persistence
{
    public interface IPasswordService
    {
        string HashPassword(string password, out string salt);
        bool VerifyPassword(string password, string hash, string salt);
    }
}
