using System.Text;
using U22552792_INF354_HW03_Backend.Data;
using U22552792_INF354_HW03_Backend.Models.IRepositories;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace U22552792_INF354_HW03_Backend.Models.Repositories
{
    public class AuthRepository: IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterUserAsync(string email, string password)
        {
            // Hash the password
            string hashedPassword = HashPassword(password);

            // Create new user
            User user = new User
            {
                Email = email,
                Password = hashedPassword
            };

            // Add user to database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return null;

            // Validate password
            if (!VerifyPassword(password, user.Password))
                return null;

            return user;
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

            return storedHash.Equals(hashedPassword);
        }
    }
}
