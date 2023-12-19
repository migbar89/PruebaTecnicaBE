namespace AppUsers.Dominio.Interfaces;

public interface IUserService
{
    Task<UserModel> CreateUserAsync(UserModel user);
    Task<IEnumerable<UserModel>> GetUsersAsync();

}