using MoneyTracker.DTOs;
using MoneyTracker.Models;

namespace MoneyTracker.Services
{
    public interface ITransactionService
    {
        public Task<IEnumerable<TransactionDto>> GetAllTransactions();

        public Task<TransactionDto> GetTransaction(int id);

        public Task<TransactionDto> AddTransaction(TransactionCreateDto Transaction);

        public Task<TransactionDto> UpdateTransaction(TransactionDto Transaction);

        public void DeleteTransaction(int id);
    }
}
