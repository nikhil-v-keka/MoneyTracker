using MoneyTracker.Models;

namespace MoneyTracker.Repositories
{
    public interface ITransactionRepository
    {
        public Task<IEnumerable<Transaction>> GetAllTransactions();

        public Task<Transaction> GetTransaction(int id);

        public Task<Transaction> AddTransaction (Transaction expense);

        public Task<Transaction> UpdateTransaction (Transaction expense);

        public Task DeleteTransaction (int id);
    }
}
