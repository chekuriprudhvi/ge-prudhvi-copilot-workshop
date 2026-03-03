---
name: generate-backend-component
description: Describe when to use this prompt
---
# BudgetWise Backend - GitHub Copilot Instructions

## Project Overview
This is the ASP.NET Core Web API backend for BudgetWise, a personal finance and budget tracking application. It targets **.NET 8** and follows RESTful API design principles with an in-memory mock data store.

## Architecture

```
backend/
├── Controllers/        # REST API endpoint definitions (thin layer, no business logic)
├── Services/           # Business logic and data access
├── Models/             # Domain models and DTOs (use record types for DTOs)
├── Data/               # MockData.cs - in-memory data store
├── Program.cs          # App entry point, DI registration, middleware pipeline
└── BudgetWise.Api.csproj  # Project dependencies
```

## C# Coding Standards

- Use **C# 12** features: primary constructors, collection expressions, `required` modifier
- Use `var` for local variables when the type is obvious
- **PascalCase** for classes, methods, properties
- **camelCase** for local variables and parameters
- Place `using` statements inside namespace declarations
- Use nullable reference types (`?`) for optional properties
- Use `ArgumentNullException.ThrowIfNull()` for null guards

## Controller Rules

✅ DO:
- Return `IActionResult` with typed results (`Ok()`, `NotFound()`, `BadRequest()`, `Created()`)
- Use `[FromQuery]` for filter parameters, `[FromBody]` for request payloads
- Use `[FromRoute]` for path parameters (`{id}`)
- Add XML documentation to all public actions
- Delegate ALL business logic to services

❌ DO NOT:
- Put business logic in controllers
- Return `null` from endpoints (use `NotFound()` instead)
- Use service locator pattern (always inject via constructor)

### Controller Template
```csharp
/// <summary>
/// Summary of what this action does.
/// </summary>
/// <param name="id">The resource ID.</param>
/// <returns>The resource if found, otherwise 404.</returns>
[HttpGet("{id}")]
public IActionResult GetById(Guid id)
{
    var result = _service.GetById(id);
    if (result == null)
        return NotFound(new { message = $"Resource with ID {id} not found" });

    return Ok(result);
}
```

## Service Rules

✅ DO:
- Register services with appropriate lifetimes (`Scoped`, `Singleton`, `Transient`)
- Use `ArgumentNullException.ThrowIfNull()` for input validation
- Return `null` (not exceptions) when a resource is not found
- Keep methods focused — single responsibility principle

❌ DO NOT:
- Use empty catch blocks
- Ignore exceptions
- Access `MockData` directly from controllers

### Service Template
```csharp
/// <summary>
/// Service for managing [resource] operations.
/// </summary>
public class ResourceService
{
    private readonly List<Resource> _resources;

    public ResourceService()
    {
        _resources = MockData.Resources;
    }

    /// <summary>
    /// Gets a resource by its unique identifier.
    /// </summary>
    public Resource? GetById(Guid id) =>
        _resources.FirstOrDefault(r => r.Id == id);

    /// <summary>
    /// Adds a new resource to the store.
    /// </summary>
    public void Add(Resource resource)
    {
        ArgumentNullException.ThrowIfNull(resource);
        _resources.Add(resource);
    }
}
```

## DTO Rules

- Use `record` types for all DTOs (immutable by default)
- Use `required` modifier for mandatory properties
- Apply Data Annotations for validation
- Create separate Request and Response DTOs

### DTO Template
```csharp
/// <summary>
/// Request model for creating a new [resource].
/// </summary>
public record CreateResourceRequest
{
    [Required]
    [MaxLength(200)]
    public required string Name { get; init; }

    [Required]
    [Range(0.01, 1_000_000)]
    public required decimal Amount { get; init; }

    [MaxLength(500)]
    public string? Notes { get; init; }
}
```

## API Design Conventions

| Operation | HTTP Method | Route | Status Codes |
|-----------|------------|-------|-------------|
| Get all | `GET` | `/api/resources` | 200 |
| Get by ID | `GET` | `/api/resources/{id}` | 200, 404 |
| Filter | `GET` | `/api/resources?category=X` | 200 |
| Create | `POST` | `/api/resources` | 201, 400 |
| Update | `PUT` | `/api/resources/{id}` | 200, 404, 400 |
| Delete | `DELETE` | `/api/resources/{id}` | 204, 404 |

## Testing Standards

- Framework: **xUnit**
- Pattern: **Arrange, Act, Assert (AAA)**
- Naming: `MethodName_WhenCondition_ThenExpectedResult`
- Use `WebApplicationFactory<T>` for integration tests
- Mock dependencies with **Moq**

```csharp
[Fact]
public void GetById_WhenExpenseExists_ReturnsExpense()
{
    // Arrange
    var service = new ExpenseService();
    var existingId = MockData.Expenses.First().Id;

    // Act
    var result = service.GetById(existingId);

    // Assert
    Assert.NotNull(result);
    Assert.Equal(existingId, result.Id);
}
```

## Mock Data Guidelines

- All data lives in `Data/MockData.cs` as static `List<T>` collections
- Data resets on every app restart (by design for the workshop)
- Keep mock data realistic (real categories, reasonable amounts, valid dates)
- Use `Guid.NewGuid()` for all IDs

## Key Dependencies

| Package | Purpose |
|---------|---------|
| `Microsoft.AspNetCore.OpenApi` | OpenAPI/Swagger spec generation |
| `Swashbuckle.AspNetCore` | Swagger UI at `/swagger` |
| `Microsoft.AspNetCore.Authentication.JwtBearer` | JWT token validation |
| `System.IdentityModel.Tokens.Jwt` | JWT token creation |
| `FluentValidation.AspNetCore` | Model validation |
| `xunit` | Unit testing framework |
| `Moq` | Mocking for unit tests |

## Development Commands

```bash
cd budgetwise-app/backend
dotnet restore       # Restore NuGet packages
dotnet build         # Build the project
dotnet run           # Run API on http://localhost:5000
dotnet watch run     # Run with hot reload
dotnet test          # Run all tests
```

## Workshop TODO Items

When implementing `// TODO:` items:
1. Follow the existing patterns in adjacent code
2. Write tests for the new implementation
3. Add XML documentation
4. Update `MockData.cs` if new sample data is needed