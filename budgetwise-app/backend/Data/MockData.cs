using BudgetWise.Api.Models;

namespace BudgetWise.Api.Data;

/// <summary>
/// Provides mock data for the BudgetWise application during development.
/// This simulates a database with sample expenses and users.
/// </summary>
public static class MockData
{
    /// <summary>
    /// Sample user for testing and development
    /// </summary>
    public static User DemoUser { get; } = new User
    {
        Id = 1,
        Username = "demo",
        Email = "demo@budgetwise.com",
        PasswordHash = "demo123", // In production, this would be properly hashed
        FirstName = "Alex",
        LastName = "Johnson",
        CreatedAt = DateTime.UtcNow.AddMonths(-6),
        LastLoginAt = DateTime.UtcNow.AddHours(-2)
    };

    /// <summary>
    /// Sample expenses for the demo user
    /// </summary>
    public static List<Expense> Expenses { get; } = new List<Expense>
    {
        new Expense
        {
            Id = 1,
            Description = "Grocery shopping at Whole Foods",
            Amount = 127.45m,
            Date = DateTime.UtcNow.AddDays(-1),
            Category = "Groceries",
            Notes = "Weekly grocery run",
            IsRecurring = false,
            UserId = 1,
            CreatedAt = DateTime.UtcNow.AddDays(-1)
        },
        new Expense
        {
            Id = 2,
            Description = "Monthly rent payment",
            Amount = 1850.00m,
            Date = DateTime.UtcNow.AddDays(-5),
            Category = "Housing",
            Notes = "Apartment rent for December",
            IsRecurring = true,
            UserId = 1,
            CreatedAt = DateTime.UtcNow.AddDays(-5)
        },
        new Expense
        {
            Id = 3,
            Description = "Electric bill",
            Amount = 95.30m,
            Date = DateTime.UtcNow.AddDays(-3),
            Category = "Utilities",
            Notes = null,
            IsRecurring = true,
            UserId = 1,
            CreatedAt = DateTime.UtcNow.AddDays(-3)
        },
        new Expense
        {
            Id = 4,
            Description = "Netflix subscription",
            Amount = 15.99m,
            Date = DateTime.UtcNow.AddDays(-10),
            Category = "Entertainment",
            Notes = "Premium plan",
            IsRecurring = true,
            UserId = 1,
            CreatedAt = DateTime.UtcNow.AddDays(-10)
        },
        new Expense
        {
            Id = 5,
            Description = "Gas station fill-up",
            Amount = 52.80m,
            Date = DateTime.UtcNow.AddDays(-2),
            Category = "Transportation",
            Notes = "Shell gas station",
            IsRecurring = false,
            UserId = 1,
            CreatedAt = DateTime.UtcNow.AddDays(-2)
        },
        new Expense
        {
            Id = 6,
            Description = "Coffee at Starbucks",
            Amount = 6.75m,
            Date = DateTime.UtcNow,
            Category = "Food & Dining",
            Notes = "Morning latte",
            IsRecurring = false,
            UserId = 1,
            CreatedAt = DateTime.UtcNow
        },
        new Expense
        {
            Id = 7,
            Description = "Gym membership",
            Amount = 49.99m,
            Date = DateTime.UtcNow.AddDays(-15),
            Category = "Health & Fitness",
            Notes = "Monthly membership fee",
            IsRecurring = true,
            UserId = 1,
            CreatedAt = DateTime.UtcNow.AddDays(-15)
        },
        new Expense
        {
            Id = 8,
            Description = "Amazon purchase - Electronics",
            Amount = 189.99m,
            Date = DateTime.UtcNow.AddDays(-7),
            Category = "Shopping",
            Notes = "Wireless headphones",
            IsRecurring = false,
            UserId = 1,
            CreatedAt = DateTime.UtcNow.AddDays(-7)
        },
        new Expense
        {
            Id = 9,
            Description = "Restaurant dinner",
            Amount = 78.50m,
            Date = DateTime.UtcNow.AddDays(-4),
            Category = "Food & Dining",
            Notes = "Birthday dinner with friends",
            IsRecurring = false,
            UserId = 1,
            CreatedAt = DateTime.UtcNow.AddDays(-4)
        },
        new Expense
        {
            Id = 10,
            Description = "Car insurance premium",
            Amount = 145.00m,
            Date = DateTime.UtcNow.AddDays(-20),
            Category = "Insurance",
            Notes = "Quarterly payment",
            IsRecurring = true,
            UserId = 1,
            CreatedAt = DateTime.UtcNow.AddDays(-20)
        },
        new Expense
        {
            Id = 11,
            Description = "Spotify Premium",
            Amount = 10.99m,
            Date = DateTime.UtcNow.AddDays(-8),
            Category = "Entertainment",
            Notes = "Music streaming service",
            IsRecurring = true,
            UserId = 1,
            CreatedAt = DateTime.UtcNow.AddDays(-8)
        },
        new Expense
        {
            Id = 12,
            Description = "Pharmacy - Medications",
            Amount = 35.50m,
            Date = DateTime.UtcNow.AddDays(-6),
            Category = "Health & Fitness",
            Notes = "Monthly prescription",
            IsRecurring = true,
            UserId = 1,
            CreatedAt = DateTime.UtcNow.AddDays(-6)
        }
    };

    /// <summary>
    /// Available expense categories with their colors
    /// </summary>
    public static List<(string Name, string Color)> Categories { get; } = new List<(string, string)>
    {
        ("Groceries", "#22c55e"),
        ("Housing", "#3b82f6"),
        ("Utilities", "#f59e0b"),
        ("Entertainment", "#8b5cf6"),
        ("Transportation", "#06b6d4"),
        ("Food & Dining", "#ec4899"),
        ("Health & Fitness", "#14b8a6"),
        ("Shopping", "#f97316"),
        ("Insurance", "#64748b"),
        ("Education", "#6366f1"),
        ("Personal Care", "#d946ef"),
        ("Travel", "#0ea5e9"),
        ("Subscriptions", "#a855f7"),
        ("Other", "#78716c")
    };

    private static int _nextExpenseId = 13;

    /// <summary>
    /// Gets the next available expense ID
    /// </summary>
    public static int GetNextExpenseId() => _nextExpenseId++;
}
