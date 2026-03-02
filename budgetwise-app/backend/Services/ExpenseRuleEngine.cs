using BudgetWise.Api.Models;

namespace BudgetWise.Api.Services;

// TODO: Lab 6 - Implement ExpenseRuleEngine
// This service should validate expenses against configurable rules
// and flag transactions that meet certain criteria

/// <summary>
/// Service for validating expenses against business rules
/// </summary>
public class ExpenseRuleEngine
{
    // TODO: Lab 6 - Create a list of configurable rules
    // private readonly List<IExpenseRule> _rules = new();

    /// <summary>
    /// Validates an expense against all configured rules
    /// </summary>
    public List<string> ValidateExpense(ExpenseDto expense)
    {
        var warnings = new List<string>();

        // TODO: Lab 6 - Implement rule validation
        // Example rules to implement:
        
        // Rule 1: Flag expenses over $100
        // if (expense.Amount > 100)
        // {
        //     warnings.Add($"High-value expense: ${expense.Amount:F2} exceeds $100 threshold");
        // }

        // Rule 2: Flag expenses in certain categories that exceed limits
        // Rule 3: Flag duplicate expenses (same amount, same day)
        // Rule 4: Flag expenses outside normal spending hours
        // Rule 5: Flag expenses that push category over budget

        return warnings;
    }

    // TODO: Lab 6 - Create IExpenseRule interface
    // public interface IExpenseRule
    // {
    //     string Name { get; }
    //     string Description { get; }
    //     bool IsEnabled { get; set; }
    //     decimal? Threshold { get; set; }
    //     bool Evaluate(ExpenseDto expense);
    //     string GetWarningMessage(ExpenseDto expense);
    // }

    // TODO: Lab 6 - Implement specific rules
    // public class HighValueExpenseRule : IExpenseRule { ... }
    // public class DuplicateExpenseRule : IExpenseRule { ... }
    // public class CategoryLimitRule : IExpenseRule { ... }
}
