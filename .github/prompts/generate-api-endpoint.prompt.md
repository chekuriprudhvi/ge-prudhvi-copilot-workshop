---
description: 'Generate an ASP.NET Core REST API endpoint with proper error handling'
agent: 'agent'
---

# Generate ASP.NET Core REST API Endpoint

Create a new REST API endpoint in the BudgetWise ASP.NET Core application.

Endpoint path: ${input:path:/api/expenses}
HTTP method: ${input:method:GET}
Purpose: ${input:purpose:Retrieve expenses}
Controller class: ${input:controller:ExpensesController}

## Requirements:

### ASP.NET Core Attributes
- Use appropriate HTTP method attributes (`[HttpGet]`, `[HttpPost]`, `[HttpPut]`, `[HttpDelete]`)
- Return `IActionResult` or typed results (e.g., `Ok<T>`, `NotFound()`, `BadRequest()`)
- Use `[FromRoute]`, `[FromQuery]`, or `[FromBody]` as appropriate for parameters

### Request Validation
- Include Data Annotations for validation (`[Required]`, `[MaxLength]`, `[Range]`, etc.)
- Validate path and query parameters
- Return 400 Bad Request for validation failures with clear error messages
- Use `ModelState.IsValid` to check validation

### Error Handling
- Add comprehensive error handling
- Return proper HTTP status codes (200, 201, 400, 404, 500)
- Include meaningful error messages in responses
- Create error response models if needed

### Documentation
- Include XML documentation comments with:
  - `<summary>` describing the endpoint
  - `<param>` for all parameters
  - `<returns>` for return value
  - `<exception>` for exceptions (if any)
- Add inline comments for complex logic

### RESTful Conventions
- Use plural nouns for collections (`/expenses` not `/expense`)
- Use HTTP methods correctly (GET for read, POST for create, etc.)
- Return 201 Created for POST requests with Location header
- Return 204 No Content for successful DELETE
- Include resource ID in Location header for created resources

### Code Quality
- Follow ASP.NET Core best practices
- Use dependency injection for services
- Keep controller methods focused and thin (delegate to services)
- Use meaningful variable names
- Use async/await for potentially blocking operations

## Example Structure:

```csharp
/// <summary>
/// ${purpose}
/// </summary>
/// <param name="param">Description of parameter</param>
/// <returns>An IActionResult containing the result</returns>
[Http${method}("${path}")]
public async Task<IActionResult> MethodName([FromQuery] string param)
{
    // Input validation
    if (string.IsNullOrWhiteSpace(param))
    {
        return BadRequest(new { message = "Parameter cannot be empty" });
    }

    try
    {
        // Call service to perform business logic
        var result = await _service.PerformOperationAsync(param);

        // Check if result exists
        if (result == null)
        {
            return NotFound(new { message = $"Resource not found for parameter: {param}" });
        }

        // Success response
        return Ok(result);
    }
    catch (ArgumentException ex)
    {
        return BadRequest(new { message = ex.Message });
    }
    catch (Exception ex)
    {
        // Log the exception here
        return StatusCode(500, new { message = "An internal error occurred", detail = ex.Message });
    }
}
```

## Additional Guidelines

### For POST Endpoints (Create)
```csharp
[HttpPost]
public async Task<IActionResult> CreateExpense([FromBody] CreateExpenseRequest request)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    var expense = await _expenseService.CreateAsync(request);
    return CreatedAtAction(nameof(GetExpenseById), new { id = expense.Id }, expense);
}
```

### For PUT Endpoints (Update)
```csharp
[HttpPut("{id}")]
public async Task<IActionResult> UpdateExpense(Guid id, [FromBody] UpdateExpenseRequest request)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    var success = await _expenseService.UpdateAsync(id, request);
    return success ? NoContent() : NotFound();
}
```

### For DELETE Endpoints
```csharp
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteExpense(Guid id)
{
    var success = await _expenseService.DeleteAsync(id);
    return success ? NoContent() : NotFound();
}
```

Generate the complete endpoint method with all necessary using statements, attributes, and error handling following ASP.NET Core best practices.
