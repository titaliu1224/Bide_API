using Bide_API.Models;

namespace Bide_API.Services;

public interface IAuthService {
    public string GenerateJwtToken(User user);
    public string EncryptToken(string token);
    public string DecryptToken(string encryptedToken);
    public string GenerateToken(string userId);
}