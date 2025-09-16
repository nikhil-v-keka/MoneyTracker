using Microsoft.EntityFrameworkCore;
using MoneyTracker.Data;
using MoneyTracker.Models;

namespace MoneyTracker.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {

        private readonly AppDbContext _dbContext;

        public TransactionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            return await _dbContext.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetTransaction(int id)
        {
            return await _dbContext.Transactions.FindAsync(id);
        }

        public async Task<Transaction> AddTransaction(Transaction expense)
        {
            var result = await _dbContext.Transactions.AddAsync(expense);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Transaction> UpdateTransaction(Transaction transaction)
        {
            var selectedTransaction = await _dbContext.Transactions.FirstOrDefaultAsync(e => e.Id == transaction.Id);

            if (selectedTransaction == null)
            {
                return null;
            }

            selectedTransaction.Id = transaction.Id;
            selectedTransaction.Name = transaction.Name;
            selectedTransaction.Amount = transaction.Amount;
            selectedTransaction.Description = transaction.Description;

            await _dbContext.SaveChangesAsync();

            return selectedTransaction;

        }

        public async Task DeleteTransaction(int id)
        {
            var selectedExpense = _dbContext.Transactions.FirstOrDefault(e => e.Id == id);
            if(selectedExpense == null)
            {
                return;
            }

            _dbContext.Remove(selectedExpense);
            await _dbContext.SaveChangesAsync();
        }

    }
}
