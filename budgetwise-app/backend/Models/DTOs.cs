namespace BudgetWise.Api.Models;

/// <summary>
/// Data transfer object for login requests
/// </summary>
public class LoginRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

/// <summary>
/// Data transfer object for login responses
/// </summary>
public class LoginResponse
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public UserDto? User { get; set; }
    public string? Token { get; set; }
}

/// <summary>
/// Data transfer object for user information (without sensitive data)
/// </summary>
public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

/// <summary>
/// Data transfer object for expense creation and updates
/// </summary>
public class ExpenseDto
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Category { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public bool IsRecurring { get; set; }
}

// TODO: Lab 3 - Create DTOs for Budget and Category operations
// public class BudgetDto { ... }
// public class CategoryDto { ... }

// TODO: Lab 6 - Create DTO for expense rule validation
// public class ExpenseRuleResult
// {
//     public bool HasWarning { get; set; }
//     public string? Message { get; set; }
//     public string? RuleName { get; set; }
// }
