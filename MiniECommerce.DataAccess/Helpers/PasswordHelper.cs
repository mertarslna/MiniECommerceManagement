using System.Security.Cryptography;

namespace MiniECommerce.DataAccess.Helpers
{
    public static class PasswordHelper
    {
        private const int SaltSize = 16; // 128 bit
        private const int KeySize = 32;  // 256 bit
        private const int Iterations = 100000; // İşlem zorluğu (Artırılabilir)
        private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA256;

        public static string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                Iterations,
                HashAlgorithm,
                KeySize);

            return $"{Convert.ToHexString(salt)}:{Convert.ToHexString(hash)}";
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split(':');
            byte[] salt = Convert.FromHexString(parts[0]);
            byte[] hash = Convert.FromHexString(parts[1]);

            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                Iterations,
                HashAlgorithm,
                KeySize);

            return CryptographicOperations.FixedTimeEquals(hash, inputHash);
        }
    }
}