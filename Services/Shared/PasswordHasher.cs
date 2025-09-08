using BCrypt.Net;

namespace AdvFullstack_Labb1.Services.Shared
{
    public class PasswordHasher
    {
        private const int WorkFactor = 11;

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: WorkFactor);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
