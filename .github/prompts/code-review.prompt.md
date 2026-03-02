---
description: 'Perform thorough code review with ASP.NET Core best practices checklist'
agent: 'ask'
---

# Code Review Checklist

Perform a thorough code review focusing on ASP.NET Core best practices, code quality, security, and maintainability.

## Review Criteria

### Code Quality
- [ ] Code follows C# naming conventions
- [ ] Methods are focused and have single responsibility
- [ ] No code duplication (DRY principle)
- [ ] Proper use of async/await patterns
- [ ] Meaningful variable and method names
- [ ] Proper use of nullable reference types

### ASP.NET Core Best Practices
- [ ] Uses dependency injection properly
- [ ] Proper use of controller attributes (`[HttpGet]`, `[HttpPost]`, etc.)
- [ ] Appropriate HTTP status codes returned
- [ ] RESTful endpoint design follows conventions
- [ ] Proper model validation with Data Annotations
- [ ] Correct use of DTOs vs domain models

### Error Handling
- [ ] Exceptions are properly handled
- [ ] No empty catch blocks
- [ ] Meaningful error messages
- [ ] Proper use of `IActionResult` or typed results
- [ ] Input validation on all endpoints
- [ ] Global exception handling configured

### Security
- [ ] No SQL injection vulnerabilities (not applicable for mock data)
- [ ] Input validation on all endpoints
- [ ] No sensitive data in logs or responses
- [ ] Proper authentication/authorization (if applicable)
- [ ] CORS configured correctly
- [ ] No hardcoded secrets or credentials

### Testing
- [ ] Unit tests exist for new code
- [ ] Tests follow AAA pattern (Arrange, Act, Assert)
- [ ] Mocks used appropriately
- [ ] Edge cases covered
- [ ] Tests are readable and maintainable
- [ ] Integration tests for API endpoints

### Documentation
- [ ] Public methods have XML documentation comments
- [ ] Complex logic is explained with comments
- [ ] README updated if needed
- [ ] API documentation (Swagger) is accurate

### Performance
- [ ] Async/await used properly for I/O operations
- [ ] No unnecessary object creation
- [ ] Efficient LINQ queries
- [ ] Proper use of collections

### Frontend (React/TypeScript)
- [ ] TypeScript types are properly defined
- [ ] React hooks used correctly
- [ ] No prop drilling (use context where appropriate)
- [ ] Proper error handling in API calls
- [ ] Accessibility attributes included
- [ ] Tailwind classes used consistently

## Example Review Comment

```
❌ Issue: Synchronous method used for potentially blocking operation
📝 Location: ExpenseService.cs, line 25
🔧 Suggestion: Convert method to async and use async/await pattern
📚 Why: Async operations prevent thread blocking and improve scalability

Before:
public Expense GetById(Guid id)
{
    return _expenses.FirstOrDefault(e => e.Id == id);
}

After:
public async Task<Expense?> GetByIdAsync(Guid id)
{
    return await Task.Run(() => _expenses.FirstOrDefault(e => e.Id == id));
}
```
