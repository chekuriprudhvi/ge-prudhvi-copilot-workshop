using Microsoft.AspNetCore.Mvc;

namespace BudgetWise.Api.Controllers;

// TODO: Lab 3 - Implement BudgetsController
// This controller should provide CRUD operations for budget management

/// <summary>
/// Endpoints for managing budgets
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BudgetsController : ControllerBase
{
    // TODO: Lab 3 - Implement GET all budgets
    // [HttpGet]
    // public IActionResult GetAll() { ... }

    // TODO: Lab 3 - Implement GET budget by ID
    // [HttpGet("{id}")]
    // public IActionResult GetById(int id) { ... }

    // TODO: Lab 3 - Implement POST for creating budgets
    // [HttpPost]
    // public IActionResult Create([FromBody] BudgetDto dto) { ... }

    // TODO: Lab 3 - Implement PUT for updating budgets
    // [HttpPut("{id}")]
    // public IActionResult Update(int id, [FromBody] BudgetDto dto) { ... }

    // TODO: Lab 3 - Implement DELETE for removing budgets
    // [HttpDelete("{id}")]
    // public IActionResult Delete(int id) { ... }

    // TODO: Lab 4 - Implement budget status/progress endpoint
    // [HttpGet("{id}/status")]
    // public IActionResult GetBudgetStatus(int id) { ... }
    // Returns: spent amount, remaining amount, percentage used, days remaining
}
