using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Bide_API.Models;
using Bide_API.Services;
using Microsoft.IdentityModel.Tokens;

namespace Bide_API.Helpers;

public class AuthService: IAuthService {
    // TODO: Move secret into settings.json
    private static string secret = "wiKSAJETb2r3MGl2hoNp5SrWKijTy8x3";

    // public string GenerateJwtToken(User user) {
    //     var tokenHandler = new JwtSecurityTokenHandler();
    //     var key = Encoding.ASCII.GetBytes(secret);
    //
    //     var claims = new List<Claim> {
    //         new Claim("user_id", user.userId),
    //         new Claim("username", user.userName)
    //     };
    //
    //     var tokenDescriptor = new SecurityTokenDescriptor {
    //         Subject = new ClaimsIdentity(claims),
    //         Expires = DateTime.UtcNow.AddDays(7),
    //         SigningCredentials =
    //             new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    //     };
    //
    //     var jwtToken = tokenHandler.CreateToken(tokenDescriptor);
    //
    //     return tokenHandler.WriteToken(jwtToken);
    // }
    
    public string EncryptToken(string token) {
        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(secret);
        aes.GenerateIV();
        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using var memoryStream = new MemoryStream();
        memoryStream.Write(aes.IV, 0, aes.IV.Length);
        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
        using (var streamWriter = new StreamWriter(cryptoStream)) {
            streamWriter.Write(token);
        }

        return Convert.ToBase64String(memoryStream.ToArray());
    }

    public string DecryptToken(string encryptedToken) {
        Console.WriteLine(encryptedToken);
        if (string.IsNullOrEmpty(encryptedToken) || !IsBase64String(encryptedToken)) {
            return ",,";
        }

        var fullCipher = Convert.FromBase64String(encryptedToken);

        using (var aes = Aes.Create()) {
            var iv = new byte[aes.IV.Length];
            var cipher = new byte[fullCipher.Length - iv.Length];

            Array.Copy(fullCipher, iv, iv.Length);
            Array.Copy(fullCipher, iv.Length, cipher, 0, cipher.Length);

            aes.Key = Encoding.UTF8.GetBytes(secret);
            aes.IV = iv;
            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (var memoryStream = new MemoryStream(cipher))
            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
            using (var streamReader = new StreamReader(cryptoStream)) {
                return streamReader.ReadToEnd();
            }
        }
    }
    
    public string GenerateToken(string userId) {
        const string validationPassword = "Bide";
        var expirationDate = DateTime.UtcNow.AddHours(24);
        var data = $"{userId},{validationPassword},{expirationDate}";
        return EncryptToken(data);
    }
    
    
    private bool IsBase64String(string str)
    {
        str = str.Trim();
        const string base64Pattern = @"^[a-zA-Z0-9\+/]*={0,3}$";
        return (str.Length % 4 == 0) && Regex.IsMatch(str, base64Pattern, RegexOptions.None);
    }

    // public bool Authenticate(string token) {
    //     try {
    //         
    //     }
    // }
}