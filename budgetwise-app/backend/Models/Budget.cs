namespace BudgetWise.Api.Models;

// TODO: Lab 3 - Create the Budget model
// This model should track budget limits for different categories
// Include properties for:
// - Id (int)
// - Name (string)
// - Amount (decimal) - the budget limit
// - CategoryId (int?) - optional link to a specific category
// - StartDate (DateTime)
// - EndDate (DateTime)
// - UserId (int)
// - CreatedAt (DateTime)

/// <summary>
/// Represents a budget allocation for tracking spending limits
/// </summary>
public class Budget
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    // TODO: Lab 3 - Add remaining properties for budget tracking
    // Add: Amount, CategoryId, StartDate, EndDate, UserId, CreatedAt
}
