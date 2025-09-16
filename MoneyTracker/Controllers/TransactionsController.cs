using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.DTOs;
using MoneyTracker.Models;
using MoneyTracker.Repositories;
using MoneyTracker.Services;

namespace MoneyTracker.Controllers
{
    [Route("api/[controller]")]

    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllContacts()
        {
            return Ok(await _transactionService.GetAllTransactions());

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TransactionDto>> GetExpenseById(int id)
        {
            var expense = await _transactionService.GetTransaction(id);
            return Ok(expense);
        }

        [HttpPost]
        public async Task<ActionResult<TransactionDto>> AddExpense(TransactionCreateDto expense)
        {
            return await _transactionService.AddTransaction(expense);
        }

        [HttpPut()]
        public async Task<ActionResult<TransactionDto>> UpdateExpense(TransactionDto expense)
        {
            return await _transactionService.UpdateTransaction(expense);
        }

        [HttpDelete("{id:int}")]
        public void DeleteExpense(int id)
        {
            _transactionService.DeleteTransaction(id);
        }

    }
    
}
