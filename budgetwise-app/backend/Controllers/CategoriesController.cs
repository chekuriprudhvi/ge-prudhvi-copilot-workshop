using Microsoft.AspNetCore.Mvc;
using BudgetWise.Api.Data;

namespace BudgetWise.Api.Controllers;

// TODO: Lab 3 - Implement CategoriesController
// This controller should provide CRUD operations for expense categories

/// <summary>
/// Endpoints for managing expense categories
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    /// <summary>
    /// Gets all available expense categories
    /// </summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        var categories = MockData.Categories
            .Select(c => new { c.Name, c.Color })
            .ToList();
        return Ok(categories);
    }

    // TODO: Lab 3 - Implement GET by ID
    // [HttpGet("{id}")]
    // public IActionResult GetById(int id) { ... }

    // TODO: Lab 3 - Implement POST for creating categories
    // [HttpPost]
    // public IActionResult Create([FromBody] CategoryDto dto) { ... }

    // TODO: Lab 3 - Implement PUT for updating categories
    // [HttpPut("{id}")]
    // public IActionResult Update(int id, [FromBody] CategoryDto dto) { ... }

    // TODO: Lab 3 - Implement DELETE for removing categories
    // [HttpDelete("{id}")]
    // public IActionResult Delete(int id) { ... }
}
