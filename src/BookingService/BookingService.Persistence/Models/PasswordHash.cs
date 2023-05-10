using BookingService.Application.Interfaces.Persistence;
using System.Security.Cryptography;
using System.Text;

namespace BookingService.Persistence.Models
{
    public class PasswordHash : IPasswordHash
    {
        private const int keySize = 64;
        private const int iterations = 200000;
        private HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        public string HashPassword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }

        public bool VerifyPassword(string password, string hash, string salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), Convert.FromHexString(salt), iterations, hashAlgorithm, keySize);
            return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
        }
    }
}
