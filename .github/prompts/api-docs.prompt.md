---
description: 'Generate comprehensive API documentation for ASP.NET Core endpoints'
agent: 'agent'
---

# Generate API Documentation

Generate comprehensive API documentation for ASP.NET Core Web API endpoints.

## Documentation Requirements:

### Endpoint Summary
- Clear, concise summary (one line)
- Detailed description (2-3 sentences explaining purpose and use case)
- Tags for grouping related endpoints

### Parameters
- Path parameters with types and descriptions
- Query parameters with defaults and examples
- Request body schema with property descriptions
- Mark required vs optional parameters clearly

### Response Documentation
- Success response (200, 201, etc.) with example JSON
- Error responses (400, 404, 500) with example error messages
- Schema definitions for complex objects

### Request/Response Examples
- Realistic example data using BudgetWise domain
- Show actual expense descriptions, categories, amounts
- Include edge cases in examples (empty lists, null values)

### Security & Authentication
- Note if endpoint requires authentication
- Specify required permissions or roles

### ASP.NET Core API Standards
- Use camelCase for JSON properties
- Include pagination details for list endpoints
- Document rate limiting if applicable
- Mention any deprecation warnings

## Example Structure:
```yaml
paths:
  /api/expenses/{id}:
    get:
      summary: Get expense by ID
      description: Retrieves detailed information about a specific expense including amount, category, date, and notes
      tags:
        - Expenses
      parameters:
        - name: id
          in: path
          required: true
          description: Unique identifier of the expense (GUID)
          schema:
            type: string
            format: uuid
      responses:
        200:
          description: Expense found successfully
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/Expense'
              example:
                id: "3fa85f64-5717-4562-b3fc-2c963f66afa6"
                userId: "demo-user-001"
                description: "Grocery shopping at Whole Foods"
                amount: 127.50
                category: "Food & Dining"
                date: "2024-12-08T10:30:00Z"
                notes: "Weekly groceries"
                createdAt: "2024-12-08T10:35:00Z"
        404:
          description: Expense not found
          content:
            application/json:
              example:
                message: "Expense with ID 3fa85f64-5717-4562-b3fc-2c963f66afa6 not found"
```

Generate complete API documentation (Swagger/OpenAPI format) for the selected ASP.NET Core controller method.
