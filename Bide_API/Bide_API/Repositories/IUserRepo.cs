using Bide_API.Models;

namespace Bide_API.Repositories;

public interface IUserRepo {
    public Task<IEnumerable<User>> GetUserInfo(string userId);
    public Task CreateUser(User user);
}