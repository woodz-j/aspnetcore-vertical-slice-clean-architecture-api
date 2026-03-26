namespace MyApi.Application.Abstractions;

public interface IAuthService
{
    Task<string?> LoginAsync(string email, string password, CancellationToken cancellationToken = default);
}