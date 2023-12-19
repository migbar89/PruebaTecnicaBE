using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.net7.Data.Repositories;



public class UserRepository : IUserRepository
{
    private readonly UserContext _ctx;
    public UserRepository(UserContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        var people = await _ctx.People.ToListAsync();
        return people;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        _ctx.People.Add(user);
        await _ctx.SaveChangesAsync();
        return user;
    }

    public async Task<User> GetUserFilter(string userName, string email)
    {
        return _ctx.People.Where(x => x.UserName.Contains(userName) || x.Email.Contains(email)).FirstOrDefault();

    }

}