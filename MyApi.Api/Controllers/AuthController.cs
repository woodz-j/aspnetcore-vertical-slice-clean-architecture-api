using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Api.Auth;
using MyApi.Api.Features.Auth.Login;
using MyApi.Application.Abstractions;
using MyApi.Infrastructure.Data;

namespace MyApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    //private readonly AppDbContext _db;
    //private readonly JwtTokenGenerator _tokenGenerator;
    //private readonly IPasswordHasherService _passwordHasher;

    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var token = await _authService.LoginAsync(request.Email, request.Password, cancellationToken);

        if (token is null)
            return Unauthorized(new { message = "Invalid email or password." });

        return Ok(new { token });
    }
    /*public AuthController(AppDbContext db, JwtTokenGenerator tokenGenerator, IPasswordHasherService passwordHasher)
    {
        _db = db;
        _tokenGenerator = tokenGenerator;
        _passwordHasher = passwordHasher;
    }*/

    /*
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _db.Users
            .FirstOrDefaultAsync(x => x.Email == request.Email);

        if (user is null)
            return Unauthorized(new { message = "Invalid email or password." });

        // TEMP: plain text compare (we fix next step)
        //if (user.PasswordHash != request.Password)
        if (!_passwordHasher.VerifyPassword(user.PasswordHash, request.Password))
                return Unauthorized(new { message = "Invalid email or password." });

        var token = _tokenGenerator.GenerateToken(
            userId: user.Id.ToString(),
            email: user.Email,
            role: user.Role);

        return Ok(new { token });
    }*/

    /*public IActionResult Login([FromBody] LoginRequest request)
    {
        // Demo-only hardcoded login
        if (request.Email == "admin@test.com" && request.Password == "Password123!")
        {
            var token = _tokenGenerator.GenerateToken(
                userId: "1",
                email: request.Email,
                role: "Admin");

            return Ok(new { token });
        }

        if (request.Email == "user@test.com" && request.Password == "Password123!")
        {
            var token = _tokenGenerator.GenerateToken(
                userId: "2",
                email: request.Email,
                role: "User");

            return Ok(new { token });
        }

        return Unauthorized(new { message = "Invalid email or password." });
    }
    */
}