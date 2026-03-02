# Copilot Instruction Best Practices

This guide provides best practices for creating effective instruction files that guide GitHub Copilot to produce high-quality, consistent code.

## Why Instructions Matter

Well-crafted instruction files:
- Ensure consistent code style across your team
- Encode project-specific patterns and conventions
- Reduce code review cycles
- Help new developers produce quality code faster
- Make Copilot suggestions more relevant and accurate

## Instruction File Types

### Repository Instructions (`.github/copilot-instructions.md`)

Project-specific guidance that applies to everyone working in the repository.

**Best For:**
- Coding standards
- Framework patterns
- Project architecture
- Technology decisions

### Personal Instructions (GitHub Settings)

Individual preferences that apply across all your repositories.

**Best For:**
- Communication preferences
- Coding style preferences
- Common patterns you use

### Organization Instructions

Company-wide standards set by administrators.

**Best For:**
- Security requirements
- Compliance standards
- Corporate coding guidelines

## Key Elements of Effective Instructions

### 1. Architecture Patterns

```markdown
## Project Architecture

This is a layered .NET application:
- Controllers handle HTTP requests and responses
- Services contain business logic
- Repositories handle data access
- Models represent data structures

Always follow this separation of concerns.
```

### 2. Technology Stack

```markdown
## Technology Stack

- .NET 8 with C# 12
- ASP.NET Core Web API
- Entity Framework Core for data access
- React 18 with TypeScript for frontend
- Tailwind CSS for styling

Use these technologies when generating code.
```

### 3. Code Style

```markdown
## Code Style

- Use meaningful, descriptive variable names
- Add XML documentation comments to public members
- Follow Microsoft C# coding conventions
- Use async/await for asynchronous operations
- Prefer LINQ over manual loops where appropriate
```

### 4. Component Patterns

```markdown
## Component Patterns

Controllers:
- Return ActionResult types
- Use constructor dependency injection
- Validate input with DataAnnotations

Services:
- Define interfaces for all services
- Handle business logic and validation
- Throw custom exceptions for errors

Frontend Components:
- Use functional components with hooks
- Define TypeScript interfaces for props
- Follow single responsibility principle
```

### 5. Error Handling

```markdown
## Error Handling

- Wrap external calls in try-catch blocks
- Use custom exception types for business errors
- Log errors with structured logging
- Return appropriate HTTP status codes
- Include error details in development, hide in production
```

### 6. Security Requirements

```markdown
## Security

- Validate all user input
- Use parameterized queries (never concatenate SQL)
- Sanitize output to prevent XSS
- Use HTTPS for all API calls
- Follow OWASP guidelines for common vulnerabilities
```

### 7. Testing Standards

```markdown
## Testing

- Write unit tests for all business logic
- Use xUnit for .NET tests
- Use Jest for React component tests
- Aim for meaningful test coverage
- Mock external dependencies
- Use Arrange-Act-Assert pattern
```

## Instruction Structure Template

```markdown
# Project: [Project Name]

## Overview
Brief description of the project and its purpose.

## Technology Stack
List of technologies, frameworks, and versions.

## Architecture
Description of project structure and patterns.

## Coding Standards
Style guidelines and conventions.

## Component Patterns
How to structure different component types.

## Security Requirements
Security practices to follow.

## Testing Standards
How to write and organize tests.

## Common Patterns
Frequently used patterns with examples.

## What to Avoid
Anti-patterns and practices to avoid.
```

## Writing Tips

### Be Specific
❌ "Write clean code"
✅ "Use descriptive variable names, limit functions to 30 lines, add XML documentation to public methods"

### Provide Examples
```markdown
## Naming Conventions

Controllers: `{Entity}Controller.cs` (e.g., `ExpensesController.cs`)
Services: `{Entity}Service.cs` (e.g., `ExpenseService.cs`)
Interfaces: `I{ServiceName}.cs` (e.g., `IExpenseService.cs`)
```

### Be Concise
Focus on what's unique to your project. Don't repeat general best practices that Copilot already knows.

### Keep Updated
Review and update instructions as your project evolves. Outdated instructions can lead to inconsistent code.

## Common Pitfalls

1. **Too vague** - Generic instructions don't provide value
2. **Too long** - Copilot has context limits; prioritize key points
3. **Outdated** - Old instructions conflict with current practices
4. **Conflicting** - Instructions at different levels contradict
5. **Overly restrictive** - Too many rules limit Copilot's effectiveness

## Measuring Effectiveness

Track these indicators:
- Code review feedback frequency
- Consistency of generated code
- Time to productive output for new developers
- Reduction in pattern-related bugs

## Auto-Generating Instructions

VS Code can help create initial instructions:
1. Open Copilot Chat
2. Click the gear icon → "Generate Chat Instructions"
3. Review and refine the suggested content
4. Customize for your specific needs

**Tip**: Run this periodically to capture new patterns as your codebase evolves.

## Additional Resources

- [GitHub Copilot Instructions Documentation](https://docs.github.com/copilot/customizing-copilot/adding-custom-instructions)
- [Prompt Engineering Best Practices](https://docs.github.com/copilot/using-github-copilot/prompt-engineering-for-github-copilot)
