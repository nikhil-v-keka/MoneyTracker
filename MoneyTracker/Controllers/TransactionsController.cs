using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Models;
using MoneyTracker.Repositories;

namespace MoneyTracker.Controllers
{
    [Route("api/[controller]")]

    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionsController(ITransactionRepository expenseRepository)
        {
            _transactionRepository = expenseRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllContacts()
        {
            return Ok(await _transactionRepository.GetAllTransactions());

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Transaction>> GetExpenseById(int id)
        {
            var expense = await _transactionRepository.GetTransaction(id);
            return Ok(expense);
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> AddExpense(Transaction expense)
        {
            return await _transactionRepository.AddTransaction(expense);
        }

        [HttpPut()]
        public async Task<ActionResult<Transaction>> UpdateExpense(Transaction expense)
        {
            return await _transactionRepository.UpdateTransaction(expense);
        }

        [HttpDelete]
        public void DeleteExpense(int id)
        {
            _transactionRepository.DeleteTransaction(id);
        }

    }
    
}
