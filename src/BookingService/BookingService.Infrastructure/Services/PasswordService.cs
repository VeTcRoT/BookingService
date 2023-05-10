using BookingService.Application.Interfaces.Services.Infrastructure;
using System.Security.Cryptography;
using System.Text;

namespace BookingService.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        private const int keySize = 64;
        private const int iterations = 200000;
        private HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        public string HashPassword(string password, out string saltReturn)
        {
            var salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            saltReturn = Convert.ToHexString(salt);

            return Convert.ToHexString(hash);
        }

        public bool VerifyPassword(string password, string hash, string salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), Convert.FromHexString(salt), iterations, hashAlgorithm, keySize);
            return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
        }
    }
}
