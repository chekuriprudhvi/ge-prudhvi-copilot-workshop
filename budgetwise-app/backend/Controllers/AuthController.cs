using Microsoft.AspNetCore.Mvc;
using BudgetWise.Api.Models;
using BudgetWise.Api.Services;

namespace BudgetWise.Api.Controllers;

/// <summary>
/// Authentication endpoints for the BudgetWise API
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Authenticates a user and returns a token
    /// </summary>
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var response = _authService.Authenticate(request);
        
        if (response.Success)
        {
            return Ok(response);
        }

        return Unauthorized(response);
    }

    /// <summary>
    /// Gets the current logged-in user information
    /// </summary>
    [HttpGet("me")]
    public IActionResult GetCurrentUser()
    {
        // In production, this would validate the JWT token
        // and return the actual authenticated user
        var user = _authService.GetCurrentUser();
        return Ok(user);
    }

    /// <summary>
    /// Logs out the current user
    /// </summary>
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        // In production, this would invalidate the token
        return Ok(new { Message = "Logged out successfully" });
    }
}
