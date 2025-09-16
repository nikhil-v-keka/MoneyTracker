using MoneyTracker.Models;

namespace MoneyTracker.Services
{
    public interface ITransactionService
    {
        public Task<IEnumerable<Transaction>> GetAllExpenses();

        public Task<Transaction> GetExpense(int id);

        public Task<Transaction> AddExpense(Transaction expense);

        public Task<Transaction> UpdateExpense(Transaction expense);

        public void DeleteExpense(int id);
    }
}
