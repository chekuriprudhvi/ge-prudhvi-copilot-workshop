# Generate Mock Expense Data

Please generate additional mock expense data entries for the BudgetWise finance tracking application. The data should follow the existing structure in the backend `MockData.cs` or frontend `mockData.ts`.

## Instructions

1. How many new expense entries would you like to add to the mock data? (Please specify a number)

## Data Structure Reference

### Backend (C#)
Each expense entry should include:
```csharp
new Expense
{
    Id = Guid.NewGuid(),
    UserId = "demo-user-001",
    Description = "Descriptive name",
    Amount = 127.50m,
    Category = "Category name",
    Date = DateTime.UtcNow.AddDays(-X),
    Notes = "Optional notes",
    CreatedAt = DateTime.UtcNow,
    UpdatedAt = null
}
```

### Frontend (TypeScript)
Each expense entry should include:
```typescript
{
  id: uuidv4(),
  userId: 'demo-user-001',
  description: 'Descriptive name',
  amount: 127.50,
  category: 'Category name',
  date: new Date(Date.now() - X * 24 * 60 * 60 * 1000).toISOString(),
  notes: 'Optional notes',
  createdAt: new Date().toISOString(),
  updatedAt: undefined
}
```

## Requirements

- Each entry should have unique IDs (use Guid.NewGuid() for C# or uuidv4() for TypeScript)
- Use realistic expense categories from BudgetWise:
  - Food & Dining
  - Transportation
  - Shopping
  - Entertainment
  - Bills & Utilities
  - Healthcare
  - Travel
  - Personal Care
  - Education
  - Other
- Include diverse expense descriptions that match the category
- Use realistic amounts (range: $5 - $500 for most, $500-$2000 for bills/rent)
- Include dates within the last 60 days
- Include optional notes for some entries (not all)
- All expenses should use userId "demo-user-001"

## Example Entries

### C#
```csharp
new Expense
{
    Id = Guid.NewGuid(),
    UserId = "demo-user-001",
    Description = "Grocery shopping at Whole Foods",
    Amount = 127.50m,
    Category = "Food & Dining",
    Date = DateTime.UtcNow.AddDays(-3),
    Notes = "Weekly groceries",
    CreatedAt = DateTime.UtcNow.AddDays(-3),
    UpdatedAt = null
},
new Expense
{
    Id = Guid.NewGuid(),
    UserId = "demo-user-001",
    Description = "Gas - Shell Station",
    Amount = 45.00m,
    Category = "Transportation",
    Date = DateTime.UtcNow.AddDays(-5),
    Notes = null,
    CreatedAt = DateTime.UtcNow.AddDays(-5),
    UpdatedAt = null
}
```

### TypeScript
```typescript
{
  id: uuidv4(),
  userId: 'demo-user-001',
  description: 'Grocery shopping at Whole Foods',
  amount: 127.50,
  category: 'Food & Dining',
  date: new Date(Date.now() - 3 * 24 * 60 * 60 * 1000).toISOString(),
  notes: 'Weekly groceries',
  createdAt: new Date(Date.now() - 3 * 24 * 60 * 60 * 1000).toISOString()
},
{
  id: uuidv4(),
  userId: 'demo-user-001',
  description: 'Gas - Shell Station',
  amount: 45.00,
  category: 'Transportation',
  date: new Date(Date.now() - 5 * 24 * 60 * 60 * 1000).toISOString(),
  createdAt: new Date(Date.now() - 5 * 24 * 60 * 60 * 1000).toISOString()
}
```

Please provide the number of entries you'd like to generate and specify whether you want C# or TypeScript format, and I'll help create new mock data that matches these requirements.
