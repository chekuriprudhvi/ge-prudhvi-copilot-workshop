using Microsoft.AspNetCore.Mvc;

namespace BudgetWise.Api.Controllers;

/// <summary>
/// Health check endpoint for the BudgetWise API
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    /// <summary>
    /// Returns the health status of the API
    /// </summary>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            Status = "Healthy",
            Timestamp = DateTime.UtcNow,
            Version = "1.0.0",
            Service = "BudgetWise.Api"
        });
    }
}
