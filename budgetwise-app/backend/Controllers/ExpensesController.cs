using Microsoft.AspNetCore.Mvc;
using BudgetWise.Api.Models;
using BudgetWise.Api.Services;
using BudgetWise.Api.Data;

namespace BudgetWise.Api.Controllers;

/// <summary>
/// Endpoints for managing expenses in the BudgetWise API
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly ExpenseService _expenseService;

    public ExpensesController(ExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    /// <summary>
    /// Gets all expenses for the current user
    /// </summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        var expenses = _expenseService.GetAllExpenses();
        return Ok(expenses);
    }

    /// <summary>
    /// Gets a specific expense by ID
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var expense = _expenseService.GetExpenseById(id);
        if (expense == null)
        {
            return NotFound(new { Message = $"Expense with ID {id} not found" });
        }
        return Ok(expense);
    }

    /// <summary>
    /// Creates a new expense
    /// </summary>
    [HttpPost]
    public IActionResult Create([FromBody] ExpenseDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Description))
        {
            return BadRequest(new { Message = "Description is required" });
        }

        if (dto.Amount <= 0)
        {
            return BadRequest(new { Message = "Amount must be greater than zero" });
        }

        var expense = _expenseService.CreateExpense(dto);
        return CreatedAtAction(nameof(GetById), new { id = expense.Id }, expense);
    }

    // TODO: Lab 3 - Implement PUT endpoint for updating expenses
    // [HttpPut("{id}")]
    // public IActionResult Update(int id, [FromBody] ExpenseDto dto)
    // {
    //     var updated = _expenseService.UpdateExpense(id, dto);
    //     if (updated == null)
    //     {
    //         return NotFound(new { Message = $"Expense with ID {id} not found" });
    //     }
    //     return Ok(updated);
    // }

    // TODO: Lab 3 - Implement DELETE endpoint for removing expenses
    // [HttpDelete("{id}")]
    // public IActionResult Delete(int id)
    // {
    //     var deleted = _expenseService.DeleteExpense(id);
    //     if (!deleted)
    //     {
    //         return NotFound(new { Message = $"Expense with ID {id} not found" });
    //     }
    //     return NoContent();
    // }

    /// <summary>
    /// Gets expenses filtered by category
    /// </summary>
    [HttpGet("category/{category}")]
    public IActionResult GetByCategory(string category)
    {
        var expenses = _expenseService.GetExpensesByCategory(category);
        return Ok(expenses);
    }

    /// <summary>
    /// Gets expense statistics summary
    /// </summary>
    [HttpGet("summary")]
    public IActionResult GetSummary()
    {
        var total = _expenseService.GetTotalSpending();
        var byCategory = _expenseService.GetSpendingByCategory();
        
        return Ok(new
        {
            TotalSpending = total,
            ExpenseCount = MockData.Expenses.Count,
            SpendingByCategory = byCategory,
            Categories = MockData.Categories.Select(c => new { c.Name, c.Color })
        });
    }

    // TODO: Lab 4 - Implement endpoint for getting spending over time (for charts)
    // [HttpGet("spending-over-time")]
    // public IActionResult GetSpendingOverTime(
    //     [FromQuery] DateTime? startDate,
    //     [FromQuery] DateTime? endDate,
    //     [FromQuery] string groupBy = "day")
    // {
    //     var data = _expenseService.GetSpendingOverTime(
    //         startDate ?? DateTime.UtcNow.AddMonths(-1),
    //         endDate ?? DateTime.UtcNow,
    //         groupBy);
    //     return Ok(data);
    // }

    // TODO: Lab 5 - Implement CSV export endpoint
    // [HttpGet("export/csv")]
    // public IActionResult ExportToCsv(
    //     [FromQuery] DateTime? startDate,
    //     [FromQuery] DateTime? endDate)
    // {
    //     var csv = _expenseService.ExportToCsv(startDate, endDate);
    //     return File(
    //         System.Text.Encoding.UTF8.GetBytes(csv),
    //         "text/csv",
    //         $"expenses_{DateTime.UtcNow:yyyyMMdd}.csv");
    // }

    // TODO: Lab 5 - Implement PDF export endpoint
    // [HttpGet("export/pdf")]
    // public IActionResult ExportToPdf(
    //     [FromQuery] DateTime? startDate,
    //     [FromQuery] DateTime? endDate)
    // {
    //     var pdf = _expenseService.ExportToPdf(startDate, endDate);
    //     return File(pdf, "application/pdf", $"expenses_{DateTime.UtcNow:yyyyMMdd}.pdf");
    // }
}
