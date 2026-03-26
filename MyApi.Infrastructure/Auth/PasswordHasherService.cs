using Microsoft.AspNetCore.Identity;
using MyApi.Application.Abstractions;
using MyApi.Domain.Entities;

namespace MyApi.Infrastructure.Auth;

public class PasswordHasherService : IPasswordHasherService
{
    private readonly PasswordHasher<User> _hasher = new();

    public string HashPassword(string password)
    {
        var user = new User();
        return _hasher.HashPassword(user, password);
    }

    public bool VerifyPassword(string hashedPassword, string providedPassword)
    {
        var user = new User();

        var result = _hasher.VerifyHashedPassword(
            user,
            hashedPassword,
            providedPassword);

        return result == PasswordVerificationResult.Success
            || result == PasswordVerificationResult.SuccessRehashNeeded;
    }
}