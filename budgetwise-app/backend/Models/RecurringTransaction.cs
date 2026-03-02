namespace BudgetWise.Api.Models;

// TODO: Lab 3 - Create the RecurringTransaction model
// This model should track recurring expenses and income
// Include properties for:
// - Id (int)
// - Description (string)
// - Amount (decimal)
// - CategoryId (int?)
// - Frequency (RecurrenceFrequency enum - Daily, Weekly, Monthly, Yearly)
// - StartDate (DateTime)
// - EndDate (DateTime?) - null means indefinite
// - LastProcessedDate (DateTime?)
// - NextDueDate (DateTime)
// - IsActive (bool)
// - UserId (int)
// - CreatedAt (DateTime)

/// <summary>
/// Represents a recurring transaction (expense or income)
/// </summary>
public class RecurringTransaction
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    
    // TODO: Lab 3 - Add remaining properties for recurring transaction tracking
    // Add: CategoryId, Frequency, StartDate, EndDate, LastProcessedDate, NextDueDate, IsActive, UserId, CreatedAt
}

// TODO: Lab 3 - Create the RecurrenceFrequency enum
// public enum RecurrenceFrequency
// {
//     Daily,
//     Weekly,
//     BiWeekly,
//     Monthly,
//     Quarterly,
//     Yearly
// }
