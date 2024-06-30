using System.Globalization;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Bide_API.Models;
using Bide_API.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;


namespace Bide_API;

public class AuthSchemeHandler: AuthenticationHandler<SessionTokenAuthSchemeOptions> {
    private readonly IAuthService _authService;
    public AuthSchemeHandler(IOptionsMonitor<SessionTokenAuthSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IAuthService authService)
        : base(options, logger, encoder, clock) {
        _authService = authService;
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync() {
        var token = Request.Headers["token"];
        var userId = "";
        var permission = "stranger";
        if (token != string.Empty) {
            var decryptedData = _authService.DecryptToken(token!);
            var parts = decryptedData.Split(',');
            Console.WriteLine(decryptedData);
            if (parts.Length == 3) {
                userId = parts[0];
                var validationPassword = parts[1];
                var expiredTime = parts[2];
                Console.WriteLine(DateTime.TryParse(expiredTime, null, DateTimeStyles.RoundtripKind,out var expireDate));
                Console.WriteLine(DateTime.UtcNow <= expireDate);
                if (DateTime.TryParse(expiredTime, null, DateTimeStyles.RoundtripKind, out var expirationDate) &&
                    validationPassword == "Bide" && DateTime.UtcNow <= expirationDate) {
                    permission = "player";
                    Console.WriteLine($"permission: {permission}");
                }
            }
        }
        var claims = new[] {
            new Claim(ClaimTypes.Name, userId),
            new Claim(ClaimTypes.Role, !string.IsNullOrEmpty(permission) ? permission : "reader")
        };

        var identity = new ClaimsIdentity(claims, !string.IsNullOrEmpty(permission) ? permission : "reader");
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);
        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}

public class SessionTokenAuthSchemeOptions : AuthenticationSchemeOptions {
}