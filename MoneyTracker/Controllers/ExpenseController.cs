using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Models;
using MoneyTracker.Repositories;

namespace MoneyTracker.Controllers
{
    [Route("api/expenses")]

    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;
        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllContacts()
        {
            return Ok(await _expenseRepository.GetAllExpenses());

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Expense>> GetExpenseById(int id)
        {
            var expense = await _expenseRepository.GetExpense(id);
            return Ok(expense);
        }

        [HttpPost]
        public async Task<ActionResult<Expense>> AddExpense(Expense expense)
        {
            return await _expenseRepository.AddExpense(expense);
        }

        [HttpPut()]
        public async Task<ActionResult<Expense>> UpdateExpense(Expense expense)
        {
            return await _expenseRepository.UpdateExpense(expense);
        }

        [HttpDelete]
        public void DeleteExpense(int id)
        {
            _expenseRepository.DeleteExpense(id);
        }

    }
    
}
