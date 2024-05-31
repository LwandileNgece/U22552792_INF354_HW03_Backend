namespace U22552792_INF354_HW03_Backend.Models.IRepositories
{
    public interface IAuthRepository
    {
        Task<User> RegisterUserAsync(string email, string password);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> LoginAsync(string email, string password);
    }
}
