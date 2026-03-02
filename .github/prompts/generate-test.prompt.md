---
description: 'Generate comprehensive xUnit tests for ASP.NET Core classes'
agent: 'agent'
---

# Generate ASP.NET Core Test

Generate a comprehensive xUnit test class for an ASP.NET Core controller or service.

## Instructions

When asked to generate tests, please:

1. **Use xUnit** with modern patterns (`[Fact]`, `[Theory]`, `[InlineData]`)
2. **Use Moq** for mocking dependencies
3. **Follow AAA pattern**: Arrange, Act, Assert
4. **Use descriptive test names**: `MethodName_WhenCondition_ThenExpectedResult`
5. **Include edge cases**: Test happy path, error cases, and boundary conditions
6. **Mock all dependencies**: Don't use real services or external dependencies
7. **Use appropriate test patterns**:
   - `WebApplicationFactory<T>` for integration tests
   - Constructor injection with mocks for unit tests
   - `ITestOutputHelper` for test logging

## Example Output for Service Test

```csharp
using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using BudgetWise.Api.Services;
using BudgetWise.Api.Models;

namespace BudgetWise.Api.Tests.Services
{
    public class ExpenseServiceTests
    {
        private readonly ExpenseService _expenseService;
        private readonly List<Expense> _testExpenses;

        public ExpenseServiceTests()
        {
            // Arrange - Set up test data
            _testExpenses = new List<Expense>
            {
                new Expense
                {
                    Id = Guid.NewGuid(),
                    UserId = "test-user",
                    Description = "Groceries",
                    Amount = 150.00m,
                    Category = "Food & Dining",
                    Date = DateTime.UtcNow.AddDays(-1)
                },
                new Expense
                {
                    Id = Guid.NewGuid(),
                    UserId = "test-user",
                    Description = "Gas",
                    Amount = 45.00m,
                    Category = "Transportation",
                    Date = DateTime.UtcNow.AddDays(-2)
                }
            };

            _expenseService = new ExpenseService();
        }

        [Fact]
        public void GetById_WhenExpenseExists_ThenReturnsExpense()
        {
            // Arrange
            var expenseId = _testExpenses[0].Id;

            // Act
            var result = _expenseService.GetById(expenseId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expenseId, result.Id);
            Assert.Equal("Groceries", result.Description);
        }

        [Fact]
        public void GetById_WhenExpenseDoesNotExist_ThenReturnsNull()
        {
            // Arrange
            var nonExistentId = Guid.NewGuid();

            // Act
            var result = _expenseService.GetById(nonExistentId);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("Food & Dining")]
        [InlineData("Transportation")]
        public void GetByCategory_WhenCategoryExists_ThenReturnsFilteredExpenses(string category)
        {
            // Arrange & Act
            var result = _expenseService.GetByCategory(category);

            // Assert
            Assert.NotEmpty(result);
            Assert.All(result, e => Assert.Equal(category, e.Category));
        }

        [Fact]
        public void Add_WhenExpenseIsValid_ThenAddsExpense()
        {
            // Arrange
            var newExpense = new Expense
            {
                Id = Guid.NewGuid(),
                UserId = "test-user",
                Description = "Coffee",
                Amount = 5.50m,
                Category = "Food & Dining",
                Date = DateTime.UtcNow
            };
            var initialCount = _expenseService.GetAll().Count();

            // Act
            _expenseService.Add(newExpense);

            // Assert
            var expenses = _expenseService.GetAll();
            Assert.Equal(initialCount + 1, expenses.Count());
            Assert.Contains(expenses, e => e.Id == newExpense.Id);
        }

        [Fact]
        public void Add_WhenExpenseIsNull_ThenThrowsArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => _expenseService.Add(null!));
        }
    }
}
```

## Example Output for Controller Test

```csharp
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BudgetWise.Api.Controllers;
using BudgetWise.Api.Services;
using BudgetWise.Api.Models;

namespace BudgetWise.Api.Tests.Controllers
{
    public class ExpensesControllerTests
    {
        private readonly Mock<IExpenseService> _mockExpenseService;
        private readonly ExpensesController _controller;

        public ExpensesControllerTests()
        {
            _mockExpenseService = new Mock<IExpenseService>();
            _controller = new ExpensesController(_mockExpenseService.Object);
        }

        [Fact]
        public void GetExpenseById_WhenExpenseExists_ThenReturnsOkResult()
        {
            // Arrange
            var expenseId = Guid.NewGuid();
            var expense = new Expense
            {
                Id = expenseId,
                Description = "Test Expense",
                Amount = 100.00m,
                Category = "Test",
                Date = DateTime.UtcNow
            };
            _mockExpenseService.Setup(s => s.GetById(expenseId)).Returns(expense);

            // Act
            var result = _controller.GetExpenseById(expenseId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedExpense = Assert.IsType<Expense>(okResult.Value);
            Assert.Equal(expenseId, returnedExpense.Id);
            _mockExpenseService.Verify(s => s.GetById(expenseId), Times.Once);
        }

        [Fact]
        public void GetExpenseById_WhenExpenseDoesNotExist_ThenReturnsNotFound()
        {
            // Arrange
            var expenseId = Guid.NewGuid();
            _mockExpenseService.Setup(s => s.GetById(expenseId)).Returns((Expense?)null);

            // Act
            var result = _controller.GetExpenseById(expenseId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
            _mockExpenseService.Verify(s => s.GetById(expenseId), Times.Once);
        }

        [Fact]
        public void GetAllExpenses_WhenExpensesExist_ThenReturnsOkWithExpenses()
        {
            // Arrange
            var expenses = new List<Expense>
            {
                new Expense { Id = Guid.NewGuid(), Description = "Expense 1", Amount = 50m, Category = "Test", Date = DateTime.UtcNow },
                new Expense { Id = Guid.NewGuid(), Description = "Expense 2", Amount = 75m, Category = "Test", Date = DateTime.UtcNow }
            };
            _mockExpenseService.Setup(s => s.GetAll()).Returns(expenses);

            // Act
            var result = _controller.GetAllExpenses();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedExpenses = Assert.IsAssignableFrom<IEnumerable<Expense>>(okResult.Value);
            Assert.Equal(2, ((List<Expense>)returnedExpenses).Count);
        }
    }
}
```

## Coverage Requirements

- Test all public methods in the class
- Include positive and negative test cases
- Test boundary conditions (null, empty, max values)
- Test exception handling
- Achieve at least 80% code coverage
- Use `[Theory]` and `[InlineData]` for parameterized tests
- Mock all external dependencies
