namespace BudgetWise.Api.Models;

// TODO: Lab 3 - Create the Category model
// This model should organize expenses into categories
// Include properties for:
// - Id (int)
// - Name (string)
// - Description (string?)
// - Color (string) - for UI display (hex color code)
// - Icon (string?) - optional icon name
// - UserId (int) - owner of the category
// - IsDefault (bool) - whether this is a system default category
// - CreatedAt (DateTime)

/// <summary>
/// Represents a category for organizing expenses and budgets
/// </summary>
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    // TODO: Lab 3 - Add remaining properties for category management
    // Add: Description, Color, Icon, UserId, IsDefault, CreatedAt
}
