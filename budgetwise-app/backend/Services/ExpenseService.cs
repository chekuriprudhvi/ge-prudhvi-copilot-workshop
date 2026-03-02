using BudgetWise.Api.Data;
using BudgetWise.Api.Models;

namespace BudgetWise.Api.Services;

/// <summary>
/// Service for managing expense operations
/// </summary>
public class ExpenseService
{
    /// <summary>
    /// Gets all expenses for the demo user
    /// </summary>
    public List<ExpenseDto> GetAllExpenses()
    {
        return MockData.Expenses
            .OrderByDescending(e => e.Date)
            .Select(e => new ExpenseDto
            {
                Id = e.Id,
                Description = e.Description,
                Amount = e.Amount,
                Date = e.Date,
                Category = e.Category,
                Notes = e.Notes,
                IsRecurring = e.IsRecurring
            })
            .ToList();
    }

    /// <summary>
    /// Gets an expense by ID
    /// </summary>
    public ExpenseDto? GetExpenseById(int id)
    {
        var expense = MockData.Expenses.FirstOrDefault(e => e.Id == id);
        if (expense == null) return null;

        return new ExpenseDto
        {
            Id = expense.Id,
            Description = expense.Description,
            Amount = expense.Amount,
            Date = expense.Date,
            Category = expense.Category,
            Notes = expense.Notes,
            IsRecurring = expense.IsRecurring
        };
    }

    /// <summary>
    /// Creates a new expense
    /// </summary>
    public ExpenseDto CreateExpense(ExpenseDto dto)
    {
        var expense = new Expense
        {
            Id = MockData.GetNextExpenseId(),
            Description = dto.Description,
            Amount = dto.Amount,
            Date = dto.Date,
            Category = dto.Category,
            Notes = dto.Notes,
            IsRecurring = dto.IsRecurring,
            UserId = MockData.DemoUser.Id,
            CreatedAt = DateTime.UtcNow
        };

        MockData.Expenses.Add(expense);

        dto.Id = expense.Id;
        return dto;
    }

    // TODO: Lab 3 - Implement UpdateExpense method
    // public ExpenseDto? UpdateExpense(int id, ExpenseDto dto)
    // {
    //     // Find existing expense
    //     // Update properties
    //     // Return updated DTO
    // }

    // TODO: Lab 3 - Implement DeleteExpense method
    // public bool DeleteExpense(int id)
    // {
    //     // Find and remove expense
    //     // Return success status
    // }

    /// <summary>
    /// Gets expenses filtered by category
    /// </summary>
    public List<ExpenseDto> GetExpensesByCategory(string category)
    {
        return MockData.Expenses
            .Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(e => e.Date)
            .Select(e => new ExpenseDto
            {
                Id = e.Id,
                Description = e.Description,
                Amount = e.Amount,
                Date = e.Date,
                Category = e.Category,
                Notes = e.Notes,
                IsRecurring = e.IsRecurring
            })
            .ToList();
    }

    /// <summary>
    /// Gets expenses within a date range
    /// </summary>
    public List<ExpenseDto> GetExpensesByDateRange(DateTime startDate, DateTime endDate)
    {
        return MockData.Expenses
            .Where(e => e.Date >= startDate && e.Date <= endDate)
            .OrderByDescending(e => e.Date)
            .Select(e => new ExpenseDto
            {
                Id = e.Id,
                Description = e.Description,
                Amount = e.Amount,
                Date = e.Date,
                Category = e.Category,
                Notes = e.Notes,
                IsRecurring = e.IsRecurring
            })
            .ToList();
    }

    /// <summary>
    /// Gets total spending amount
    /// </summary>
    public decimal GetTotalSpending()
    {
        return MockData.Expenses.Sum(e => e.Amount);
    }

    /// <summary>
    /// Gets spending grouped by category
    /// </summary>
    public Dictionary<string, decimal> GetSpendingByCategory()
    {
        return MockData.Expenses
            .GroupBy(e => e.Category)
            .ToDictionary(g => g.Key, g => g.Sum(e => e.Amount));
    }

    // TODO: Lab 4 - Implement GetSpendingOverTime for charting
    // Returns spending data grouped by day/week/month for visualization
    // public List<SpendingDataPoint> GetSpendingOverTime(DateTime startDate, DateTime endDate, string groupBy = "day")
    // {
    //     // Group expenses by date
    //     // Calculate running totals
    //     // Return data points for charting
    // }

    // TODO: Lab 5 - Implement ExportToCsv
    // public string ExportToCsv(DateTime? startDate = null, DateTime? endDate = null)
    // {
    //     // Build CSV string with headers
    //     // Add expense rows
    //     // Return CSV content
    // }

    // TODO: Lab 5 - Implement ExportToPdf
    // public byte[] ExportToPdf(DateTime? startDate = null, DateTime? endDate = null)
    // {
    //     // Generate PDF document
    //     // Add formatted expense report
    //     // Return PDF bytes
    // }
}
