using Bide_API.Models;
using Bide_API.Repositories;

namespace Bide_API.Services;

public class UserService: IUserService {
    private readonly IUserRepo _userRepo;

    public UserService(IUserRepo userRepo) {
        _userRepo = userRepo;
    }

    public async Task<LoginInfo> Login(string userId, string password) {
        var loginResult = new LoginInfo {
            userId = userId,
            message = await IsLoginSuccess(userId, password),
            userName = ""
        };
        if (loginResult.message != "Success") {
            return loginResult;
        }

        loginResult.userName = await GetUserName(userId);
        return loginResult;
    }

    private async Task<string> IsLoginSuccess(string userId, string password) {
        var userInfo = await _userRepo.GetUserInfo(userId);
        var userInfoList = userInfo.ToList();
        if (userInfoList.Count == 0) {
            return "User ID is not exist.";
        }

        return password != userInfoList.First().password ? "Password is wrong." : "Success";
    }

    private async Task<string> GetUserName(string userId) {
        var userInfo = await _userRepo.GetUserInfo(userId);
        return userInfo.First().userName;
    }

    public void CreateUser(User user) {
        
    }
}