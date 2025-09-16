using MoneyTracker.Models;
using MoneyTracker.Repositories;

namespace MoneyTracker.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository trasactionRepository)
        { 
            _transactionRepository = trasactionRepository;
        }

        public Task<Transaction> AddExpense(Transaction expense)
        {
            throw new NotImplementedException();
        }

        public void DeleteExpense(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetAllExpenses()
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetExpense(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> UpdateExpense(Transaction expense)
        {
            throw new NotImplementedException();
        }
    }
}
