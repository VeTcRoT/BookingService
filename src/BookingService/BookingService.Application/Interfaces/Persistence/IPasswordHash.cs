namespace BookingService.Application.Interfaces.Persistence
{
    public interface IPasswordHash
    {
        string HashPassword(string password, out byte[] salt);
        bool VerifyPassword(string password, string hash, string salt);
    }
}
