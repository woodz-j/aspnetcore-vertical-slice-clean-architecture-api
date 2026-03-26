using MyApi.Application.Abstractions;

namespace MyApi.Api.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepository _users;
    private readonly IPasswordHasherService _passwordHasher;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public AuthService(
        IUserRepository users,
        IPasswordHasherService passwordHasher,
        JwtTokenGenerator tokenGenerator)
    {
        _users = users;
        _passwordHasher = passwordHasher;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<string?> LoginAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        var user = await _users.GetByEmailAsync(email, cancellationToken);

        if (user is null)
            return null;

        if (!_passwordHasher.VerifyPassword(user.PasswordHash, password))
            return null;

        return _tokenGenerator.GenerateToken(
            user.Id.ToString(),
            user.Email,
            user.Role);
    }
}