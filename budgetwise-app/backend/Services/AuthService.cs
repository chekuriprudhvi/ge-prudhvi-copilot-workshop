using BudgetWise.Api.Data;
using BudgetWise.Api.Models;

namespace BudgetWise.Api.Services;

/// <summary>
/// Service for authentication and user management
/// </summary>
public class AuthService
{
    /// <summary>
    /// Authenticates a user with username and password
    /// </summary>
    public LoginResponse Authenticate(LoginRequest request)
    {
        // For demo purposes, we use a simple check
        // In production, this would use proper password hashing and JWT tokens
        if (request.Username == "demo" && request.Password == "demo123")
        {
            MockData.DemoUser.LastLoginAt = DateTime.UtcNow;
            
            return new LoginResponse
            {
                Success = true,
                Message = "Login successful",
                User = new UserDto
                {
                    Id = MockData.DemoUser.Id,
                    Username = MockData.DemoUser.Username,
                    Email = MockData.DemoUser.Email,
                    FirstName = MockData.DemoUser.FirstName,
                    LastName = MockData.DemoUser.LastName
                },
                Token = GenerateDemoToken()
            };
        }

        return new LoginResponse
        {
            Success = false,
            Message = "Invalid username or password"
        };
    }

    /// <summary>
    /// Gets the current logged-in user (demo user)
    /// </summary>
    public UserDto GetCurrentUser()
    {
        return new UserDto
        {
            Id = MockData.DemoUser.Id,
            Username = MockData.DemoUser.Username,
            Email = MockData.DemoUser.Email,
            FirstName = MockData.DemoUser.FirstName,
            LastName = MockData.DemoUser.LastName
        };
    }

    /// <summary>
    /// Generates a demo JWT token (not for production use)
    /// </summary>
    private string GenerateDemoToken()
    {
        // This is a mock token for demo purposes
        // In production, use proper JWT token generation with secrets
        return $"demo_token_{Guid.NewGuid():N}";
    }

    // TODO: Lab 4 - Implement proper JWT authentication
    // Use Microsoft.AspNetCore.Authentication.JwtBearer
    // Generate real JWT tokens with claims
    // Validate tokens on protected endpoints
}
