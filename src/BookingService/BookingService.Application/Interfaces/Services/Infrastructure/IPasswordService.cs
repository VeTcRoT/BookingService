namespace BookingService.Application.Interfaces.Services.Infrastructure
{
    public interface IPasswordService
    {
        string HashPassword(string password, out string salt);
        bool VerifyPassword(string password, string hash, string salt);
    }
}
