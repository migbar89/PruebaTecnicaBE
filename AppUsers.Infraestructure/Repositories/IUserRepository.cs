namespace PruebaTecnica.net7.Data.Repositories;

public interface IUserRepository
{
    Task<User> CreateUserAsync(User user);
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User> GetUserFilter(string userName, string email);

}