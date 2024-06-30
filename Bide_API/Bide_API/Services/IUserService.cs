using Bide_API.Models;

namespace Bide_API.Services;

public interface IUserService {
    public Task<LoginInfo> Login(string userId, string password);
}